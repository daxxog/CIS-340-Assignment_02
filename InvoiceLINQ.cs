/* ================================================
 * @author     David Volm aka VOLMINATOR aka daXXog
 * @date       Sat Feb 12 17:58:28 CST 2022
 * @school     UWSP
 * @class      CIS 340
 * @section    01
 * @assignment 02
 * @professor  Hardeep Kaur Dhalla
 * @licence    MIT
 * ===============================================*/

using System;
using System.Linq;


namespace HardwareStore {
    class InvoiceLINQ {
        static readonly Invoice[] invoices = {
            new Invoice(
                part: 83,
                description: "Electric sander",
                count: 7,
                pricePerItem: 57.98m
            ),
            new Invoice(
                part: 24,
                description: "Power saw",
                count: 18,
                pricePerItem: 99.99m
            ),
            new Invoice(
                part: 7,
                description: "Sledge hammer",
                count: 11,
                pricePerItem: 21.50m
            ),
            new Invoice(
                part: 77,
                description: "Hammer",
                count: 76,
                pricePerItem: 11.99m
            ),
            new Invoice(
                part: 39,
                description: "Lawn mower",
                count: 3,
                pricePerItem: 79.50m
            ),
            new Invoice(
                part: 68,
                description: "Screwdriver",
                count: 106,
                pricePerItem: 6.99m
            ),
            new Invoice(
                part: 56,
                description: "Jig saw",
                count: 21,
                pricePerItem: 11.00m
            ),
            new Invoice(
                part: 3,
                description: "Wrench",
                count: 34,
                pricePerItem: 7.50m
            ),
        };

        static readonly IQueryable<Invoice> invoicesQueryable = invoices.AsQueryable();


        static void Main(string[] args) {
            System.Console.WriteLine("Sorted by description:");
            foreach(
                Invoice invoice in
                invoicesQueryable.OrderBy(
                    invoice => invoice.PartDescription
                )
            ) {
                System.Console.WriteLine(invoice);
            }


            System.Console.WriteLine();
            System.Console.WriteLine("Sorted by price:");
            foreach(
                Invoice invoice in
                invoicesQueryable.OrderBy(
                    invoice => invoice.Price
                )
            ) {
                System.Console.WriteLine(invoice);
            }


            System.Console.WriteLine();
            System.Console.WriteLine("Select description and quantity, sort by quantity:");
            foreach(
                var invoice in
                invoicesQueryable.Select(
                    invoice => new {
                        PartDescription = invoice.PartDescription,
                        Quantity = invoice.Quantity
                    }
                ).OrderBy(
                    invoice => invoice.Quantity
                )
            ) {
                System.Console.WriteLine(invoice);
            }


            System.Console.WriteLine();
            System.Console.WriteLine("Select description and invoice total, sort by invoice total:");
            foreach(
                var invoice in
                invoicesQueryable.Select(
                    invoice => new {
                        PartDescription = invoice.PartDescription,
                        InvoiceTotal = invoice.Quantity * invoice.Price
                    }
                ).OrderBy(
                    invoice => invoice.InvoiceTotal
                )
            ) {
                // need to type cast InvoiceTotal to double for output to match lab expected output
                System.Console.WriteLine($"{{ PartDescription = {invoice.PartDescription}, InvoiceTotal = {(double) invoice.InvoiceTotal} }}");
            }


            System.Console.WriteLine();
            System.Console.WriteLine("Invoice totals between {200:C} and {500:C}:");
            foreach(
                var invoice in
                invoicesQueryable.Select(
                    invoice => new {
                        PartDescription = invoice.PartDescription,
                        InvoiceTotal = invoice.Quantity * invoice.Price
                    }
                ).Where(
                    invoice => (invoice.InvoiceTotal >= 200) && (invoice.InvoiceTotal <= 500)
                ).OrderBy(
                    invoice => invoice.InvoiceTotal
                )
            ) {
                // need to type cast InvoiceTotal to double for output to match lab expected output
                System.Console.WriteLine($"{{ PartDescription = {invoice.PartDescription}, InvoiceTotal = {(double) invoice.InvoiceTotal} }}");
            }
        }
    }
}

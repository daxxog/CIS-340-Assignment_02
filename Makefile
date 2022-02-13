SHELL := /bin/bash


.PHONY: exe
exe:
	csc <(cat shims/namespace.cs ex09_03/Invoice.cs) InvoiceLINQ.cs


.PHONY: output
output: exe
	mono InvoiceLINQ.exe | tee InvoiceLINQOutput.txt


.PHONY: test
test: output
	@diff expected.out InvoiceLINQOutput.txt


.PHONY: help
help:
	@printf "available targets -->\n\n"
	@cat Makefile | grep ".PHONY" | grep -v ".PHONY: _" | sed 's/.PHONY: //g'


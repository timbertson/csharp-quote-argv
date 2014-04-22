
bin: execv.exe

execv.exe: TestMain.cs QuoteArguments.cs
	gmcs -out:execv.exe *.cs

fuzz: execv.exe
	python test.py

.PHONY: phony

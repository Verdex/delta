
cc = fsharpc

all : 
	$(cc) ConsoleUtil.fs  MainLoop.fs

clean :
	rm -rf *.exe


cc = fsharpc

all : 
	$(cc) ConsoleWriter.fs KeyboardPress.fs  MainLoop.fs

clean :
	rm -rf *.exe

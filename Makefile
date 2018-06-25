
cc = fsharpc

all : 
	$(cc) KeyboardPress.fs  MainLoop.fs

clean :
	rm -rf *.exe

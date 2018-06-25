

namespace delta


module MainLoop = 

    open System
    open System.Threading
    open KeyboardPress

    let main = 
        initKeyboardPress ()
    
        Thread.Sleep 5000 
        printfn "%A !!!!!" (getLastKeyboardPresses () )
        Thread.Sleep 5000 


        killKeyboardPress ()


        Console.WriteLine( "blah" ) 
        printfn "%A !!!!!" (getLastKeyboardPresses () )








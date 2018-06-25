
namespace delta

module KeyboardPress =

    open System.Threading
    open System

    let private flagLocker = new Object()
    let mutable private shutdownFlag = false

    let private listLocker = new Object()
    let mutable private keyPressList = []

    let private shouldShutdown () = lock flagLocker ( fun () -> shutdownFlag )

    let private recordKeyPress keyPress = 
        lock listLocker ( fun () -> 
                keyPressList <- keyPress :: keyPressList
            )

    let initKeyboardPress () =
        let thread = new Thread( fun () -> 
            while shouldShutdown() = false do
                let c = Console.ReadKey( true )
                recordKeyPress (c.KeyChar, DateTime.Now)
            )
        thread.Start()


    let killKeyboardPress () =
        lock flagLocker ( fun () -> shutdownFlag <- true )


    let getLastKeyboardPresses ()  =
        lock listLocker ( fun () -> 
            let temp = keyPressList
            keyPressList <- []
            temp
        )


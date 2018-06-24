
namespace delta

module KeyboardPress =

    open System.Threading
    open System

    let private flagLocker = new Object()
    let mutable private shutdownFlag = false

    let private listLocker = new Object()
    let mutable private keyPressList = []

    let private shouldShutdown () = lock flagLocker ( fun () -> shutdownFlag )

    let private recordKeyPressAndTrim keyPress = 
        lock listLocker ( fun () -> 
            if keyPressList.Length > 1000 then
                keyPressList <- List.take 999 keyPressList
                keyPressList <- keyPress :: keyPressList
            else
                keyPressList <- keyPress :: keyPressList 
            )


    let initKeyboardPress () =
        let thread = new Thread( fun () -> 
            while shouldShutdown() = false do
                let c = Console.ReadKey( true )
                recordKeyPressAndTrim (c.KeyChar, DateTime.Now)
            )
        thread.Start()


    let killKeyboardPress () =
        lock flagLocker ( fun () -> shutdownFlag <- true )


    let getLastKeyboardPress n =
        lock listLocker ( fun () -> List.take n keyPressList )


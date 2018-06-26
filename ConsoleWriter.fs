
namespace delta

module ConsoleWriter =

    open System

    type ConsoleChar = { Char : char
                         ForeColor : ConsoleColor
                         BackColor : ConsoleColor
                       }

    type ConsolePoint = { X : int
                          Y : int
                        }

    let writeToConsole caps =
        for (cChar, cPoint) in caps do
            Console.BackgroundColor <- cChar.BackColor
            Console.ForegroundColor <- cChar.ForeColor
            Console.SetCursorPosition( cPoint.X, cPoint.Y )
            Console.Write( cChar.Char )

    let clearConsole () = Console.Clear()
    let getConsoleWidth () = Console.WindowWidth
    let getConsoleHeight () = Console.WindowHeight




namespace delta


module MainLoop = 

    open System
    open System.Threading
    open KeyboardPress
    open ConsoleWriter

    let main = 


        clearConsole ()
         
        writeToConsole [( { Char = 'w' ; ForeColor = ConsoleColor.Blue ; BackColor = ConsoleColor.Red }, 
                          { X = 3; Y = 4 } ) ; 
                         ( { Char = 'h' ; ForeColor = ConsoleColor.Green ; BackColor =  ConsoleColor.Black }, 
                           { X = 5 ; Y = 10 } )]









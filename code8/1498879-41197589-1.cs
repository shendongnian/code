    using System;
    using System.Linq;
    
    namespace StackoverflowTests
    {
        class Program
        {
    
            public static void Main(string[] args)
            {
                Console.WriteLine("Type the IP Address: ");
                //Put the default IP address 
                var defaultIP = "192.168.0.190";
                Console.Write(defaultIP);
    
                string input = defaultIP;
                //Loop through all the keys until an enter key
                while (true)
                {
                    //read a key
                    var key = Console.ReadKey(true);
                    //Was this is a newline? 
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        break;
                    }
                    //Was is a backspace? 
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        //Did we delete too much?
                        if (Console.CursorLeft == 0)
                            continue; //suppress
                        //Put the cursor on character back
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        //Delete it with a space
                        Console.Write(" ");
                        //Put it back again
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        //Delete the last char of the input
                        input = string.Join("", input.Take(input.Length - 1));
                    }
                    //Regular key? add it to the input
                    else
                    {
                        input += key.KeyChar.ToString();
                        Console.Write(key.KeyChar);
                    }
                }
    
                Console.WriteLine("You entered: " + input);
                Console.ReadLine();
            }
        }
    }

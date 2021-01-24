    using System;
    
    namespace ConsoleTest
    {
        public class Program {
            public static string tr="";
            //I replaced my calls to Console.ReadLine() with this. The limit is the
            //max number of characters that can be entered in the console.
            public static string ReadChars(int limit)
            {
                string str = string.Empty; //all the input so far
                int left = Console.CursorLeft; //store cursor position for re-outputting
                int top = Console.CursorTop;
                
                while (true) //keep checking for key events
                {
                    if (Console.KeyAvailable)
                    {
                        //true to intercept input and not output to console
                        //normally. This sometimes fails and outputs anyway.
                        ConsoleKeyInfo c = Console.ReadKey(true);
                        string name = Enum.GetName(typeof(ConsoleKey), c.Key);
                        var key = c.KeyChar;
                        // Console.WriteLine(String.Format("Name={0}, Key={1}, KeyAscii={2}", name, key,(int)key));
                        if (c.Key == ConsoleKey.Enter) //stop input on Enter key
                            {
                                Console.WriteLine();
                                break;
                            }
                        if (c.Key == ConsoleKey.LeftArrow || c.Key == ConsoleKey.RightArrow) {
                            continue;
                        }
    
                        if (c.Key == ConsoleKey.Backspace) //remove last char on Backspace
                        {
                            if (str != "")
                            {
                                str = str.Substring(0, str.Length - 1);
                            }
                        }
                        else if (c.Key != ConsoleKey.Tab && str.Length < limit)
                        {
                            //don't allow tabs or exceeding the max size
                            str += c.KeyChar;
                        }
                        else
                        {
                            //ignore tabs and when the ilimit is exceeded
                            if (Console.CursorLeft > str.Length){
    
                                var delta = Console.CursorLeft - str.Length;
                                Console.CursorLeft = str.Length;
                                Console.Write(new String(' ',delta));
                                Console.CursorLeft = str.Length;
                            }
                            continue;
                        }
                        Console.SetCursorPosition(left, top);
                        string padding = ""; //padding clears unused chars in field
                        for (int i = 0; i < limit - str.Length; i++)
                        {
                            padding += " ";
                        }
                        //output this way instead
                        Console.Write(str + padding);
                        Console.CursorLeft = str.Length;
                    }
                }
                return str;
            }
    
            public static void Main(string[] args) {
                Console.WriteLine("Please enter some text: ");
                var text = ReadChars(10);
    
                Console.WriteLine("You entered: " + text);
            }
        }
    }

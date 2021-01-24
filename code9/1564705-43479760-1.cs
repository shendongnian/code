        static void Main(string[] args)
        {
            List<char> outputString = new List<char>();
            outputString = "test".ToCharArray().ToList();
            //If there is something in outputString write it to buffer and set cursor position
            if (outputString.Count > 0)
            {
                Console.Write(outputString.Select(x => x.ToString()).Aggregate((x, y) => x + y));
            }
            while (true)
            {
                //This will read user input but it will not print it to the console window 
                var key = Console.ReadKey(true);
                //Allow user maniputate cursor to the right
                //Here you can add another condition to prevent line overflow or some constrains
                //if(Console.CursorLeft < 30)
                if (key.Key == ConsoleKey.RightArrow && Console.CursorLeft < outputString.Count)
                {
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                }
                else if (key.Key == ConsoleKey.LeftArrow && Console.CursorLeft > 0)
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
                //Here you should add all keys that your input should take, special characters are ok above ASCII number 32 which is space
                else if (key.KeyChar >= 48 && key.KeyChar <= 57 || //Read numbers
                    key.KeyChar >= 64 && key.KeyChar <= 90 || //Read capital letters
                    key.KeyChar >= 97 && key.KeyChar <= 122 || //Read lower letters
                    key.Key == ConsoleKey.Spacebar)
                {
                    Console.Write(key.KeyChar);
                    if(Console.CursorLeft > outputString.Count)
                    {
                        outputString.Add(' ');
                    }
                    outputString[Console.CursorLeft - 1] = key.KeyChar;
                }
                //This will remove character
                else if (key.Key == ConsoleKey.Backspace && Console.CursorLeft > 1)
                {
                    ClearCurrentConsoleLine();
                    outputString.RemoveAt(Console.CursorLeft - 1);
                    var currentLeft = Console.CursorLeft;
                    Console.CursorLeft = 0;
                    Console.Write(outputString.Select(x => x.ToString()).Aggregate((x,y) => x + y));
                    Console.CursorLeft = currentLeft - 1;
                }
                //This ends input loop
                //You can add more keys to break current loop with OR condition
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            //Display result and wait for any key
            Console.WriteLine(outputString.Select(x => x.ToString()).Aggregate((x, y) => x + y));
            Console.ReadKey();
        }
        
        //Clears current console line and sets cursor at where it was before
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursorTop = Console.CursorTop;
            int currentLineCursorLeft = Console.CursorLeft;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(currentLineCursorLeft, currentLineCursorTop);
        }

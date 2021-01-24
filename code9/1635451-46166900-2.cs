        public static string CustomReadLine()
        {
                   
            ConsoleKeyInfo cki;
            string capturedInput = "";
            while (true)
            {
        
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                    break;
                else if (cki.Key == ConsoleKey.Spacebar)
                {
                    capturedInput += " ";
                    Console.Write(" ");
                }
                else if (cki.Key == ConsoleKey.Backspace)
                {
                    capturedInput = capturedInput.Remove(capturedInput.Length - 1);
                    Console.Clear();
                    Console.Write(capturedInput);
                }
                else
                {
                    capturedInput += cki.KeyChar;
                    Console.Write(cki.KeyChar);
                }
        
                if (capturedInput.ToUpper().Contains("SKILLSET"))
                {
                    capturedInput = "";
                    skillsetTyped();
                    return "";
                }
            }
        
            return capturedInput;
    }

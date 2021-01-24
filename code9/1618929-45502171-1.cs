            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine();
                string Text = "MAP" + i;
                Console.SetCursorPosition((Console.WindowWidth - Text.Length) / 2, Console.CursorTop);
                if (i == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;                    
                    Console.WriteLine(Text);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(Text);
                }
            }
        

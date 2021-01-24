        static void Main()
        {
            var lines = new List<string>();
            var density = 10;               // 10%
            // Create list of lines with random dots 
            for(int i = 0; i < Console.WindowHeight; i++)            
            {
                lines.Add(GetDottedLine(density));
            }
            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            // First print the lines from top to bottom
            for(int linesToPrint = 0; linesToPrint < lines.Count; linesToPrint++)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = linesToPrint - 1; i >= 0; i--)
                {
                    Console.Write(lines[i]);
                }
                Thread.Sleep(100);
            }
            // Once we've shown all the lines, continue to loop forever
            // by just adding a new line and removing the first one
            while(true)
            {
                lines.Remove(lines[0]);
                lines.Add(GetDottedLine(density));
                Console.SetCursorPosition(0, 0);
                for(int i = lines.Count - 1; i >= 0; i--)
                {
                    Console.Write(lines[i]);
                }
                Thread.Sleep(100);
            }
        }
    }

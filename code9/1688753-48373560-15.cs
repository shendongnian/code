        static void Main()
        {
            var lines = new List<string>();
            var density = 10; // (10% of each line will be a matrix character)
            var speed = MatrixCodeSpeed.Normal;
            // Hide the cursor - set this to 'true' again before accepting user input
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            while (true)
            {
                // Once the lines count is greater than the window height,
                // remove the first item, so that the list "scrolls" also
                if (lines.Count >= Console.WindowHeight)
                {
                    lines.Remove(lines[0]);
                }
                // Add  a new random line to the list.
                // This will be the new topmost line.
                lines.Add(GetMatrixLine(density));
                Console.SetCursorPosition(0, 0);
                // Print the lines out to the console in reverse order so the
                // first line is always last, or on the bottom of the window
                for (int i = lines.Count - 1; i >= 0; i--)
                {
                    Console.Write(lines[i]);
                }
                Thread.Sleep(TimeSpan.FromMilliseconds((int)speed));
            }
        }
    }

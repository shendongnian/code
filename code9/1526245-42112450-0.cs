    static string TimedReadline(string prompt, int seconds) {
        int y = Console.CursorTop;
        // Force a scroll if we're at the end of the buffer
        if (y == Console.BufferHeight - 1) {
            Console.WriteLine();
            Console.SetCursorPosition(0, --y);
        }
        // Setup the timer
        using (var tmr = new System.Timers.Timer(1000 * seconds)) {
            tmr.AutoReset = false;
            tmr.Elapsed += (s, e) => {
                if (Console.CursorTop != y) return;
                int x = Cursor.Left;
                Console.MoveBufferArea(0, y, Console.WindowWidth, 1, 0, y + 1);
                Console.SetCursorPosition(0, y);
                Console.Write("I just waited {0} seconds", seconds);
                Console.SetCursorPosition(x, y + 1);
            };
            tmr.Enabled = true;
            // Write the prompt and obtain the user's input
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }

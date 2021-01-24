    static void Main(string[] args)
    {
        const string txt = "STACKOVERFLOW";
        var x = 1;
        var startPos = 0;
        var col = 0;
        while (true)
        {
            do
            {
                while (!Console.KeyAvailable && (startPos <= 100 || startPos >= 0))
                {
                    startPos = col + x;
                    if (startPos < 0)
                    {
                        startPos = 0;
                        x = 1;
                    }
                    Console.SetCursorPosition(startPos, 0);
                    Console.WriteLine(txt);
                    col = startPos;
                    Thread.Sleep(500);
                    Console.Clear();
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.LeftArrow);
            x = -1;
            
        }
    }

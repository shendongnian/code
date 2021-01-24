    static void WriteHere(int x, int y, string s)
    {
        foreach (var line in s.Split('\n'))
        {
            Console.SetCursorPosition(x, y);
            Console.Write(line);
            y++;
        }
    }

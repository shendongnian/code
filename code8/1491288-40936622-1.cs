    public static void WindowColor(string Background, string Foreground)
    {
        ConsoleColor b, f;
        if (   Enum.TryParse(Background, out b)
            && Enum.TryParse(Foreground, out f))
        {
            Console.BackgroundColor = b;
            Console.ForegroundColor = f;
            Console.Clear();
        }
    }

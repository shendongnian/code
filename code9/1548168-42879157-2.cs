    static string ReadLine()
    {
        StringBuilder sb = new StringBuilder();
        while(true)
        {
            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape) return null;
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return sb.ToString();
            }
            if (keyInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
            {
                Console.Write(keyInfo.KeyChar + " " + keyInfo.KeyChar);
                sb.Length--;
                continue;
            }
            if (Char.IsControl(keyInfo.KeyChar)) continue;
            Console.Write(keyInfo.KeyChar);
            sb.Append(keyInfo.KeyChar);
        }
    }

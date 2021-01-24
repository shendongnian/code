    class Program
    {
        private static Random rnd = new Random();
        static string GetDottedLine(int density)
        {
            var chars = new[] { '░', '▒', '▓', '█' };
            var line = new StringBuilder();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                line.Append(rnd.Next(100) > density ? ' ' : chars[rnd.Next(chars.Length)]);
            }
            return line.ToString();
        }

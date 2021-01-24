    class Program
    {
        static void Main(string[] args)
        {
            var input = " SUCCESS Post Policy Success INVOICE No. :: WS1704003404 || Policy No :: 59203313 || App No. :: 123456724 ";
            var pattern = @"::\s*(\w+)\s*";
            var matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
                Console.WriteLine(match.Groups[1].Value);
        }
    }

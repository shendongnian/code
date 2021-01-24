    class Program
    {
        static void Main(string[] args)
        {
            var input = "20+5";
            var regex = new Regex(@"(\d+)(.)(\d+)");
            if (regex.IsMatch(input))
            {
                var match = regex.Match(input);
                var a = match.Groups[1].Value;
                var op = match.Groups[2].Value;
                var b = match.Groups[3].Value;
                Console.WriteLine($"a: {a}");
                Console.WriteLine($"operator: {op}");
                Console.WriteLine($"b: {b}");
            }
        }
    }

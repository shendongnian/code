        class Program
        {
            static void Main(string[] args)
            {
                var numbers = new[] { 1, 100.12, 50.218, 0.5 };
                int length = 10;
                var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                foreach (var n in numbers.Select(i => i.ToString()))
                {
                    var offset = n.Contains(separator) ? n.Length - n.IndexOf(separator) : 0;
                    string format = string.Format("{{0, {0}}}", length + offset);
                    Console.WriteLine(string.Format(format, n));
                }
            }
        }

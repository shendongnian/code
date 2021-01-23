    static void Main(string[] args)
            {
                List<string> vals = new List<string>();
                vals.Add("a1");
                vals.Add("a11");
                vals.Add("a41");
                vals.Add("a13");
                vals.Add("a12");
                vals.Add("a9");
                var result = vals.OrderByDescending(x => orderNumbers(x));
            }
            public static string orderNumbers(string input)
            {
                return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
            }

     static void Main(string[] args)
        {
            string pattern = @"(0|1|2)";
            string input = "5441.32 6140";
            Regex rgx = new Regex(pattern);
            var map = new Dictionary<string, string> {
                      { "0", "A"},
                      { "1", "B"},
                      { "2", "C" }
                     };
            string result = rgx.Replace(input,m => map[m.Value]);
            Console.WriteLine("Original String:    '{0}'", input);
            Console.WriteLine("Replacement String: '{0}'", result);
            Console.ReadLine();
        }

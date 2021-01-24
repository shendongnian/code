    class Program
    {
        private static Dictionary<string, string> _dict = new Dictionary<string, string>
        {
            {"a", "value1"},
            {"abc", "value2"},
            {"5", "value3"},
            {"rfd", "value4"},
            {"nn", "value5"},
            {"iu", "value6"}
        };
        private static void Main(string[] args)
        {
            string input = "(abc)&&(rfd)&&(5)||(hh)&&(nn)||(iu)";
            string output = Regex.Replace(input, @"(?<=\()\w+(?=\))", Lookup);
            Console.WriteLine(output);
        }
        private static string Lookup(Match m)
        {
            string result;
            _dict.TryGetValue(m.Value, out result);
            return result;
        }
    }

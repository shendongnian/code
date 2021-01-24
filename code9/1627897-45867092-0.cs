           static void Main(string[] args)
            {
                string input = "key1:value1 key2:'value2 value3'";
                string pattern = @"\s*(?'key'[^:]+):((?'value'[^'][^\s]+)|'(?'value'[^']+))";
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    Console.WriteLine("Key : '{0}', Value : '{1}'", match.Groups["key"].Value, match.Groups["value"].Value);
                }
                Console.ReadLine();
            }

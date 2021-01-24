        public static void Main(string[] args)
        {
            List<string> commands = new List<string>()
            {
                @"w\\//a/b",
                @"w\\//a\b",
                @"w\\/a\b",
                @"w:://a\b",
                @"w::/a\b",
                @"w:/a\bc::/12\xyz"
            };
            var titlist = commandCount(commands);
            foreach (var value in titlist)
            {
                Console.WriteLine(value);
            }
            Console.Read();
        }
        public static List<int> commandCount(List<string> commands)
        {
            List<int> lengths = new List<int>();
            foreach (var command in commands)
            {
                var count = 0;
                var substring = GetAllSubstring(command);
                for (int i = 0; i < substring.Count; i++)
                {
                    string input = substring[i];
                    Regex r1 = new Regex(@"^[a-z]{1}\w*\:*\/\w+\\[a-z]+$");
                    Match match = r1.Match(input);
                    if (match.Success)
                        count += match.Groups.Count;
                }
                lengths.Add(count);
            }
            return lengths;
        }
        static List<string> GetAllSubstring(string command)
        {
            List<string> substrings = new List<string>();
            char[] array = command.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                StringBuilder sub = new StringBuilder(array[i].ToString());
                substrings.Add(sub.ToString());
                for (int j = i+1; j < array.Length; j++)
                {
                    substrings.Add(sub.Append(array[j]).ToString());
                }
            }
            return substrings;
        }
    }

            public static List<string> Names = new List<string>();
        public static string Text = "I am Sangeen Khan and i am friend Jhon. Jhon is friend of Wasim.";
        static void Main(string[] args)
        {
            Names.Add("Sangeen Khan");
            Names.Add("Jhon");
            Names.Add("Wasim");
            Names.Add("Alexander");
            Names.Add("Afridi");
            var matchCount = 0;
            var nameToRemove = new List<string>();
            foreach (var name in Names)
            {
                var regex = new Regex(name);
                var match = regex.Matches(Text);
                //Count of matches
                matchCount += match.Count;
                if (match.Count > 0)
                {
                    Text = regex.Replace(Text, "\"Name\"");
                }
                else
                {
                    nameToRemove.Add(name);
                }
            }
            nameToRemove.ForEach(name=> Names.Remove(name));
            Console.WriteLine($"Names: {string.Join(" ", Names)}");
            Console.WriteLine($"Count: {matchCount}");
            Console.WriteLine($"ReplaceText: {Text}");
            Console.ReadLine();
        }

        public static IEnumerable<string> ChangeLines(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                yield return line.Replace("A C", "A B C");
            }
        }

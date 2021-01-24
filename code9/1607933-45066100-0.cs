    class Level
    {
        public string Current { get; set; }
        public string Old { get; set; }
    }
    class Program
    {
        static bool CompareLevels(ICollection<Level> levels)
        {
            foreach (var item in levels)
            {
                // Either of any level is HUB == false
                if ((item.Current == "HUB") || (item.Old == "HUB"))
                    return false;
                // Any Old level == any Current level == false
                if (levels.Any(level => level.Old == item.Current))
                    return false;
            }
            // All levels met the criteria (no exceptions/failures)
            return true;
        }
        // A simple console program to exercise the above function:
        static void Main(string[] args)
        {
            // Should return false if any Old or Current levels are HUB
            var levels = new List<Level>
            {
                new Level { Current = "HUB", Old = "ABCDEF" },
                new Level { Current = "DEFGHI", Old = "HUB" }
            };
            Console.WriteLine(CompareLevels(levels));
            // Should return false if all Old levels != any Current level
            levels = new List<Level>
            {
                new Level { Current = "ABC123", Old = "ABCDEF" },
                new Level { Current = "DEFGHI", Old = "DEF456" }
            };
            Console.WriteLine(CompareLevels(levels));
            // Should return false if any Old level == any Current level
            levels = new List<Level>
            {
                new Level { Current = "ABC123", Old = "ABCDEF" },
                new Level { Current = "DEFGHI", Old = "ABC123" }
            };
            Console.WriteLine(CompareLevels(levels));
            Console.ReadLine();
        }
    }

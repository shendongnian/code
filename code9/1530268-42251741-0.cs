    class GameNameComparer : IComparer<string>
    {
        static readonly Regex regx = new Regex(@"^(?<Name>.*) (?<Version>[\d\.]+)$", RegexOptions.ExplicitCapture);
        private static GameNameComparer instance;
        public static GameNameComparer Comparer
        {
            get
            {
                if (instance == null)
                    instance = new GameNameComparer();
                return instance;
            }
        }
        private GameNameComparer() { }
        public int Compare(string x, string y)
        {
            var m1 = regx.Match(x);
            var m2 = regx.Match(y);
            if (m1.Success && m2.Success)
            {
                var name1 = m1.Groups["Name"].Value;
                var ver1 = m1.Groups["Version"].Value;
                var name2 = m2.Groups["Name"].Value;
                var ver2 = m2.Groups["Version"].Value;
                if (String.Equals(name1, name2, StringComparison.OrdinalIgnoreCase))
                {
                    var ver1Levels = ver1.Split(new char[] { '.' });
                    var ver2Levels = ver2.Split(new char[] { '.' });
                    for (int i = 0; i < Math.Min(ver1Levels.Length, ver2Levels.Length); i++)
                    {
                        int ver1LevelNo = 0;
                        int ver2LevelNo = 0;
                        int compare = 0;
                        if (Int32.TryParse(ver1Levels[i], out ver1LevelNo) && Int32.TryParse(ver2Levels[i], out ver2LevelNo))
                        {
                            compare = ver1LevelNo.CompareTo(ver2LevelNo);
                            if (compare != 0)
                                return compare;
                        }
                        compare = ver1Levels[i].CompareTo(ver2Levels[i]);
                        if (compare != 0)
                            return compare;
                    }
                    return ver1Levels.Length.CompareTo(ver2Levels.Length);
                }
                return String.Compare(name1, name2, StringComparison.OrdinalIgnoreCase);
            }
            return String.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }

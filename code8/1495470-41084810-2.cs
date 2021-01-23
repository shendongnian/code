    public class NumberExtractorComparer : IComparer<MatchCollection>
    {
        private static readonly Regex rx = new Regex("[0-9]+");
        public static readonly NumberExtractorComparer Comparer = new NumberExtractorComparer();
        // Returns a MatchCollection composed of all the groups of
        // digits
        public static MatchCollection Selector(string str)
        {
            return rx.Matches(str);
        }
        // Compares two matchcollections
        public int Compare(MatchCollection x, MatchCollection y)
        {
            int min = Math.Min(x.Count, y.Count);
            for (int i = 0; i < min; i++)
            {
                // Using long to support bigger numbers
                long l1 = long.Parse(x[i].Value);
                long l2 = long.Parse(y[i].Value);
                int cmp = l1.CompareTo(l2);
                if (cmp != 0)
                {
                    return cmp;
                }
            }
            return x.Count.CompareTo(y.Count);
        }
    }

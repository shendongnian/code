    public class NamesComparer : IEqualityComparer<IEnumerable<string>>
    {
        public bool Equals(IEnumerable<string> x, IEnumerable<string> y)
        {
            //do your null checks
            return x.SequenceEqual(y);
        }
        public int GetHashCode(IEnumerable<string> obj)
        {
            return 0;
        }
    }

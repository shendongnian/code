    public class SequenceComparer : IEqualityComparer<IEnumerable<string>>
    {
        public bool Equals(IEnumerable<string> first, IEnumerable<string> second)
        {
            return first.SequenceEqual(second);
        }
        public int GetHashCode(IEnumerable<string> value)
        {
            return value.Aggregate(0, (a, v) => a ^ v.GetHashCode());
        }
    }

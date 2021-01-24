    class SequenceEqualityComparer : IEqualityComparer<IEnumerable<string>>
    {
        // Does not handle null values correctly.
        public bool Equals(IEnumerable<string> x, IEnumerable<string> y) => x.SequenceEqual(y);
    
        public int GetHashCode(IEnumerable<string> obj)
        {
            unchecked {
                return obj.Aggregate(17, (hash, @string) => hash * 23*@string.GetHashCode());
            }
        }
    }

    public class ValuePairRefEqualityComparer<T> : IEqualityComparer<(T,T)> where T : class
    {
        public static ValuePairRefEqualityComparer<T> Instance
            = new ValuePairRefEqualityComparer<T>();
        private ValuePairRefEqualityComparer() { }
        public bool Equals((T,T) x, (T,T) y)
        {
            return ReferenceEquals(x.Item1, y.Item1)
                && ReferenceEquals(x.Item2, y.Item2);
        }
        public int GetHashCode((T,T) obj)
        {
            return RuntimeHelpers.GetHashCode(obj.Item1)
                + 2 * RuntimeHelpers.GetHashCode(obj.Item2);
        }
    }

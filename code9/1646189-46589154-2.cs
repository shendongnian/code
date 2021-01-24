    public class ReferenceEqualityComparer<T> : IEqualityComparer<T>
    {
        public static ReferenceEqualityComparer<T> Inst = new ReferenceEqualityComparer<T>();
        private ReferenceEqualityComparer() { }
        public bool Equals(T x, T y) { return ReferenceEquals(x, y); }
        public int GetHashCode(T obj) { return RuntimeHelpers.GetHashCode(obj); }
    }

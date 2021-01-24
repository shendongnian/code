    public class Utilities
    {
        public T Max<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b)>0 ? a : b;
        }
        public bool Equals<T>(T a, T b) where T : IEquatable<T>
        {
            return a!=null ? a.Equals(b) : b==null;
        }
    }

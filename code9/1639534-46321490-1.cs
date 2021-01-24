    public class Utilities3<T> where T : IComparable
    {
        public T Max(T a, T b) 
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }

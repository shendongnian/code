    public class MyComparer<T> : IEqualityComparer<T> where T : class
    {        
        public bool Equals(T x, T y)
        {
            //your code here
        }
        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }

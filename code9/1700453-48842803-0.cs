    public class CustomHashSetEqualityComparer<T>
        : IEqualityComparer<HashSet<T>>
    {
        public bool Equals(HashSet<T> x, HashSet<T> y)
        {
            if (ReferenceEquals(x, null))
                return false;
            return x.SetEquals(y);
        }
        public int GetHashCode(HashSet<T> obj)
        {
            int hashCode = 0;
            if (obj != null)
            {
                foreach (T t in obj)
                {
                    hashCode = hashCode ^ 
                        (obj.Comparer.GetHashCode(t) & 0x7FFFFFFF);
                }
            }
            return hashCode;
        }
    }

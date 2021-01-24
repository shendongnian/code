    public class CustomHashSetEqualityComparer<T>
        : IEqualityComparer<HashSet<T>>
    {
        public bool Equals(HashSet<T> x, HashSet<T> y)
        {
            if (ReferenceEquals(x, null))
                return false;
            return x.SetEquals(y);
        }
        public int GetHashCode(HashSet<T> set)
        {
            int hashCode = 0;
            if (set != null)
            {
                foreach (T t in set)
                {
                    hashCode = hashCode ^ 
                        (set.Comparer.GetHashCode(t) & 0x7FFFFFFF);
                }
            }
            return hashCode;
        }
    }

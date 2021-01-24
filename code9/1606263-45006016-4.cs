    public class RecalculatingHashSet<T>
    {
        private List<T> originalValues = new List<T>();
        public HashSet<T> GetUnique()
        {
            return new HashSet<T>(originalValues);
        }
        public void Add(T item)
        {
            originalValues.Add(item);
        }
    }

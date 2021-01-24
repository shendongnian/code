    public class Feature<T>// : IComparable
    {
        public T StreetCode2 { get; set; }
        public string ToString(T streetCode)
        {
            if (EqualityComparer<T>.Default.Equals(StreetCode2, streetCode))
            {
                return "Equal";
            }
            return "Not Equal";
        }
    }

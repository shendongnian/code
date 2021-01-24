    public class Liste<T> : IEnumerable<T>
    {
        readonly List<T> underlyingList = new List<T>();
        public void Add(T item)
        {
            underlyingList.Add(item);
        }
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return underlyingList.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }

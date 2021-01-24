    public class MyListWrapper<T> : ISuperClonableList<T>
    {
        private readonly ISuperClonableList<T> _innerList;
        public MyListWrapper(ISuperClonableList<T> innerList)
        {
            _innerList = innerList;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _innerList).GetEnumerator();
        }
        public void Add(T item)
        {
            _innerList.Add(item);
        }
        public void Clear()
        {
            _innerList.Clear();
        }
        public bool Contains(T item)
        {
            return _innerList.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            _innerList.CopyTo(array, arrayIndex);
        }
        public bool Remove(T item)
        {
            return _innerList.Remove(item);
        }
        public int Count
        {
            get { return _innerList.Count; }
        }
        public bool IsReadOnly
        {
            get { return _innerList.IsReadOnly; }
        }
        public int IndexOf(T item)
        {
            return _innerList.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            _innerList.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            _innerList.RemoveAt(index);
        }
        public T this[int index]
        {
            get { return _innerList[index]; }
            set { _innerList[index] = value; }
        }
    }

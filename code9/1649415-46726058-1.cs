    public class MyClass: IMyClass {
        private IList<int> myList;
        private IList<int> myInnerList;
        public IList<int> MyList 
        { 
            get => myList;
            set => throw new InvalidOperationException();
        }
        MyClass() 
        {
            myInnerList = new List<int>();
            myList = new ProtectedList(myInnerList);
        }
        public void AddToList(int newVal)
        {
            myInnerList.Add(newVal);
        }
    }
    
    /// <summary>
    /// Encapsulates an IList in a way, so that you can only change it
    /// through the original IList reference.
    /// </summary>
    class ProtectedList<T> : IList<T>, IReadOnlyList<T>
    {
        private IList<T> innerList;
        public ProtectedList(IList<T> innerList) => this.innerList = innerList;
        public T this[int index]
        {
            get => innerList[index];
            set => throw new InvalidOperationException();
        }
        public int Count => innerList.Count;
        public bool IsReadOnly => true;
        public void Add(T item) => throw new InvalidOperationException();
        public void Clear() => throw new InvalidOperationException();
        public bool Contains(T item) => innerList.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => innerList.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator() => innerList.GetEnumerator();
        public int IndexOf(T item) => innerList.IndexOf(item);
        public void Insert(int index, T item) => throw new InvalidOperationException();
        public bool Remove(T item) => throw new InvalidOperationException();
        public void RemoveAt(int index) => throw new InvalidOperationException();
        IEnumerator IEnumerable.GetEnumerator() => innerList.GetEnumerator();
    }
}

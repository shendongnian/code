      public class Subset<T> : ICollection<T>
      {
        private readonly IList list_;
        public Subset(IList list) { list_ = list; }
        public IEnumerator<T> GetEnumerator() => list_.OfType<T>().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Add(T item) => list_.Add(item);
        public void Clear() => list_.Clear();
        public bool Contains(T item) => list_.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => list_.CopyTo(array, arrayIndex);
        public int Count => list_.Count;
        public bool IsReadOnly => list_.IsReadOnly;
        public bool Remove(T item) { list_.Remove(item); return true; }
      }

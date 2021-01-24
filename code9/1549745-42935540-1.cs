    public class SequentialKeyedCollection<T> : IEnumerable<T>
    {
        private T[] _innerArray;
        private int _startIndex;
        public SequentialKeyedCollection(int startIndex, int length)
        {
            _innerArray = new T[length];
            _startIndex = startIndex;
        }
        public T this[int index]
        {
            get => _innerArray[index - _startIndex];
            set => _innerArray[index - _startIndex] = value;
        }
        public int Length => _innerArray.Length;
        public int IndexOf(T item)
        {
            int i = Array.IndexOf(_innerArray, item);
            if (i < 0) return i; // Not found.
            return i + _startIndex;
        }
        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_innerArray).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)_innerArray).GetEnumerator();
    }

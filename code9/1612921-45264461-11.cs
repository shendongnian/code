    sealed class LazySinglyLinkedList<T> : IDisposable
    {
        private readonly IEnumerable<T> Enumerable;
        private IEnumerator<T> Enumerator;
        public LazySinglyLinkedList(IEnumerable<T> enumerable)
        {
            Enumerable = enumerable;
        }
        public LazySinglyLinkedListNode<T> GetListHead()
        {
            // We are deliberately not storing a reference to any of the nodes inside the list itself.
            if (Enumerator != null) throw new InvalidOperationException("GetListHead can only be called once.");
            Enumerator = Enumerable.GetEnumerator();
            if (!Enumerator.MoveNext())
            {
                // Empty collection.
                return null;
            }
            return new LazySinglyLinkedListNode<T>(Enumerator);
        }
        public void Dispose()
        {
            Enumerator?.Dispose();
        }
    }
    sealed class LazySinglyLinkedListNode<T>
    {
        private readonly IEnumerator<T> Enumerator;
        private LazySinglyLinkedListNode<T> _next;
        public T Value { get; }
        public LazySinglyLinkedListNode<T> Next
        {
            get
            {
                if (_next == null)
                {
                    if (!Enumerator.MoveNext()) return null; // We've reached the end.
                    _next = new LazySinglyLinkedListNode<T>(Enumerator);
                }
                return _next;
            }
        }
        public LazySinglyLinkedListNode(IEnumerator<T> enumerator)
        {
            Value = enumerator.Current;
            Enumerator = enumerator;
        }
    }

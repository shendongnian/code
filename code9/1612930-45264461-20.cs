    sealed class LazySinglyLinkedListNode<T>
    {
        public static LazySinglyLinkedListNode<T> Create(IEnumerator<T> enumerator)
        {
            return enumerator.MoveNext() ? new LazySinglyLinkedListNode<T>(enumerator) : null;
        }
        public T Value { get; }
        private IEnumerator<T> Enumerator;
        private LazySinglyLinkedListNode<T> _next;
        public LazySinglyLinkedListNode<T> Next
        {
            get
            {
                if (_next == null && Enumerator != null)
                {
                    if (Enumerator.MoveNext())
                    {
                        _next = new LazySinglyLinkedListNode<T>(Enumerator);
                    }
                    else
                    {
                        Enumerator = null; // We've reached the end.
                    }
                }
                return _next;
            }
        }
        private LazySinglyLinkedListNode(IEnumerator<T> enumerator)
        {
            Value = enumerator.Current;
            Enumerator = enumerator;
        }
    }

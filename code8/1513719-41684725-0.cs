    public class ImmutableStack<T>: IEnumerable<T>
    {
        public static readonly ImmutableStack<T> Empty = new ImmutableStack<T>();
        private readonly T first;
        private readonly ImmutableStack<T> rest;
        public int Count { get; }
        private ImmutableStack()
        {
            Count = 0;
        }
        private ImmutableStack(T first, ImmutableStack<T> rest)
        {
            Debug.Assert(rest != null);
            this.first = first;
            this.rest = rest;
            Count = rest.Count + 1;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = this;
            while (current != Empty)
            {
                yield return current.first;
                current = current.rest;
            }
        }
        public T Peek()
        {
            if (this == Empty)
                throw new InvalidOperationException("Can not peek an empty stack.");
            return first;
        }
        public ImmutableStack<T> Pop()
        {
            if (this == Empty)
                throw new InvalidOperationException("Can not pop an empty stack.");
            return rest;
        }
        public ImmutableStack<T> Push(T item) => new ImmutableStack<T>(item, this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

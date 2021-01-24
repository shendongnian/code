    public class Maybe<T>: IOptional<T>
    {
        private readonly IEnumerable<T> _element;
        public Maybe(T element)
            : this(new T[1] { element })
        {}
        public Maybe()
            : this(new T[0])
        {}
        private Maybe(T[] element)
        {
            _element = element;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _element.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

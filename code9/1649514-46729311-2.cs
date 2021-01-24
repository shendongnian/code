    internal struct RangeEnumerator<T> : IEnumerator<T>
    {
        private readonly MoveStrategy _move;
        private readonly IReadOnlyList<T> _source;
        private readonly int _start;
        private readonly int _end;
        // position of enumerator. not actual index. negative if reversed
        public int Position { get; private set; }
        public RangeEnumerator(IReadOnlyList<T> source, int start, int length)
        {
            start = Math.Min(Math.Max(start, 0), source.Count);
            _source = source;
            _start = start;
            _end = Math.Min(Math.Max(length + start, 0), source.Count);
            Position = -Math.Sign(length); 
            _move = null;
           
            // no this, therefor no copy
            _move = length >= 0 ? (MoveStrategy)MoveNextImpl : MovePrevImpl;
        }
        public bool MoveNext() => _move(ref this);
        public void Reset() => Position = -1;
        public T Current => _source[Position + _start];
        object IEnumerator.Current => Current;
        private static bool MoveNextImpl(ref RangeEnumerator<T> v) => ++v.Position + v._start < v._end;
        private static bool MovePrevImpl(ref RangeEnumerator<T> v) => --v.Position + v._start  >= v._end;
        private delegate bool MoveStrategy(ref RangeEnumerator<T> v);
        void IDisposable.Dispose()
        {
        }
    }

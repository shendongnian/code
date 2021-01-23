    public static class EnumerableExtensions
    {
        public static IEnumerable<string> ReadLines(this StreamReader input)
        {
            return new LineReadingEnumerable(input);
        }
        public static IEnumerable<IReadOnlyList<T>> TakeChunks<T>(this IEnumerable<T> source, int length)
        {
            return new ChunkingEnumerable<T>(source, length);
        }
        public class LineReadingEnumerable : IEnumerable<string>
        {
            private readonly StreamReader _input;
            public LineReadingEnumerable(StreamReader input)
            {
                _input = input;
            }
            public IEnumerator<string> GetEnumerator()
            {
                return new LineReadingEnumerator(_input);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        public class LineReadingEnumerator : IEnumerator<string>
        {
            private readonly StreamReader _input;
            private string _current;
            public LineReadingEnumerator(StreamReader input)
            {
                _input = input;
            }
            public void Dispose()
            {
                _input.Dispose();
            }
            public bool MoveNext()
            {
                _current = _input.ReadLine();
                return (_current != null);
            }
            public void Reset()
            {
                throw new NotSupportedException();
            }
            public string Current
            {
                get { return _current; }
            }
            object IEnumerator.Current
            {
                get { return _current; }
            }
        }
        public class ChunkingEnumerable<T> : IEnumerable<IReadOnlyList<T>>
        {
            private readonly IEnumerable<T> _inner;
            private readonly int _length;
            public ChunkingEnumerable(IEnumerable<T> inner, int length)
            {
                _inner = inner;
                _length = length;
            }
            public IEnumerator<IReadOnlyList<T>> GetEnumerator()
            {
                return new ChunkingEnumerator<T>(_inner.GetEnumerator(), _length);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
        public class ChunkingEnumerator<T> : IEnumerator<IReadOnlyList<T>>
        {
            private readonly IEnumerator<T> _inner;
            private readonly int _length;
            private IReadOnlyList<T> _current;
            private bool _endOfInner;
            public ChunkingEnumerator(IEnumerator<T> inner, int length)
            {
                _inner = inner;
                _length = length;
            }
            public void Dispose()
            {
                _inner.Dispose();
                _current = null;
            }
            public bool MoveNext()
            {
                var currentBuffer = new List<T>();
                while (currentBuffer.Count < _length && !_endOfInner)
                {
                    if (!_inner.MoveNext())
                    {
                        _endOfInner = true;
                        break;
                    }
                    currentBuffer.Add(_inner.Current);
                }
                if (currentBuffer.Count > 0)
                {
                    _current = currentBuffer;
                    return true;
                }
                _current = null;
                return false;
            }
            public void Reset()
            {
                _inner.Reset();
                _current = null;
                _endOfInner = false;
            }
            public IReadOnlyList<T> Current
            {
                get
                {
                    if (_current != null)
                    {
                        return _current;
                    }
                    throw new InvalidOperationException();
                }
            }
            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }
        }
    }

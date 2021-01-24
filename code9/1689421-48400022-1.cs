    struct StrictRangeArraySegment<T>
    {
        ArraySegment<T> _segment;
        public StrictRangeArraySegment(T[] array) 
            : this(array, 0, array.Length)
        {
        }
        public StrictRangeArraySegment(T[] array, int offset, int count)
            : this(new ArraySegment<T>(array, offset, count))
        {
        }
        public StrictRangeArraySegment(ArraySegment<T> segment)
        {
            _segment = segment;
        }
        public int Count
        {
            get
            {
                return _segment.Count;
            }
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _segment.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return _segment.Array[_segment.Offset + index];
            }
            set
            {
                if (index < 0 || index >= _segment.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                _segment.Array[_segment.Offset + index] = value;
            }
        }
    }

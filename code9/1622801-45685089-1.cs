    public static class MySequenceExtensions
    {
        public static IReadOnlyList<int> Times10Plus(
            this IReadOnlyList<int> sequence, 
            int value) => Add(sequence, 
                              value,
                              v => sequence[sequence.Count - 1] * 10 + v);
        public static IReadOnlyList<T> Starts<T>(this T first)
            => new MySequence<T>(first);
        
        public static IReadOnlyList<T> Add<T>(
            this IReadOnlyList<T> sequence,
            T item,
            Func<T, T> func)
        {
            var mySequence = sequence as MySequence<T> ?? 
                             new MySequence<T>(sequence);
            return mySequence.AddItem(item, func);
        }
        private class MySequence<T>: IReadOnlyList<T>
        {
            private readonly List<T> innerList;
            public MySequence(T item)
            {
                innerList = new List<T>();
                innerList.Add(item);
            }
            public MySequence(IEnumerable<T> items)
            {
                innerList = new List<T>(items);
            }
            public T this[int index] => innerList[index];
            public int Count => innerList.Count;
            public MySequence<T> AddItem(T item, Func<T, T> func)
            {
                Debug.Assert(innerList.Count > 0);
                innerList.Add(func(item));
                return this;
            }
            public IEnumerator<T> GetEnumerator() => innerList.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }

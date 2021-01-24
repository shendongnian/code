    public class ListComparer<T> : IComparer<IReadOnlyList<T>>
    {
        public static readonly IComparer<IReadOnlyList<T>> Default = new ListComparer<T>();
        private readonly bool _checkCount;
        private readonly int _numberOfElementsToCompare;
        private readonly IComparer<T> _elementComparer;
        public ListComparer()
            : this(true, 1, Comparer<T>.Default)
        {
        }
        public ListComparer(
            bool checkCount,
            int numberOfElementsToCompare,
            IComparer<T> elementComparer)
        {
            _checkCount = checkCount;
            _numberOfElementsToCompare = numberOfElementsToCompare;
            _elementComparer = elementComparer
                ?? throw new ArgumentNullException(nameof(elementComparer));
        }
        public int Compare(IReadOnlyList<T> x, IReadOnlyList<T> y)
        {
            if (ReferenceEquals(x, y))
                return 0;
            if (ReferenceEquals(x, null))
                return -1;
            if (ReferenceEquals(y, null))
                return 1;
            if (_checkCount)
            {
                var diff = x.Count.CompareTo(y.Count);
                if (diff != 0)
                    return diff;
            }
            return x.Take(_numberOfElementsToCompare)
                .Zip(y, (i, j) => _elementComparer.Compare(i, j))
                .SkipWhile(value => value == 0)
                .FirstOrDefault();
        }
    }

    public class SetComparison<T>
    {
        private Lazy<IImmutableSet<T>> _added;
        private Lazy<IImmutableSet<T>> _removed;
        private Lazy<IImmutableSet<T>> _intersection;
        public SetComparison(IEnumerable<T> previous, IEnumerable<T> current)
        {
            if (previous == null) throw new ArgumentNullException(nameof(previous));
            if (current == null) throw new ArgumentNullException(nameof(current));
            Previous = previous.ToImmutableHashSet();
            Current = current.ToImmutableHashSet();
            _added = new Lazy<IImmutableSet<T>>(() => Current.Except(Previous));
            _removed = new Lazy<IImmutableSet<T>>(() => Previous.Except(Current));
            _intersection = new Lazy<IImmutableSet<T>>(() => Current.Intersect(Previous));
        }
        public IImmutableSet<T> Previous { get; }
        public IImmutableSet<T> Current { get; }
        public IImmutableSet<T> Added => _added.Value;
        public IImmutableSet<T> Removed => _removed.Value;
        public IImmutableSet<T> Intersection => _intersection.Value;
    }

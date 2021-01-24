    public class Grouping<TKey, TElement> : IEnumerable<TElement>, IGrouping<TKey, TElement>
    {
        public static IGrouping<TKey, TElement> Create(TKey key, TElement element)
        {
            return new Grouping<TKey, TElement>()
            {
                Key = key,
                Elements = new TElement[] {element},
            };
        }
        public static IGrouping<TKey, TElement> Create(TKey key,
            IEnumerable<TElement> elements)
        {
            return new Grouping<TKey, TElement>()
            {
                Key = key,
                elements = elements,
            };
        }
        private Grouping() { }
        public TKey Key { get; private set; }
        private IEnumerable<TElement> elements;
        public IEnumerator<TElement> GetEnumerator() => this.elements.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

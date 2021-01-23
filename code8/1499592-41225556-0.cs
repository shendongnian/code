    public static class IEnumerableExtensions
    {
        public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
        {
            readonly List<TElement> elements;
            public Grouping(TKey key, List<TElement> elems)
            {
                Key = key;
                elements = elems;
            }
            public TKey Key { get; private set; }
            public IEnumerator<TElement> GetEnumerator()
            {
                return this.elements.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }
        public static IEnumerable<IGrouping<TKey, TElement>> GroupByConcurrent<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        where TKey : IEquatable<TKey>
        {
            if (source == null)
                throw new ArgumentNullException("source");
            TKey currentKey = default(TKey);
            List<TElement> currentList = null;
            foreach (var s in source)
            {
                var key = keySelector.Invoke(s);
                var elem = elementSelector.Invoke(s);
                if (!key.Equals(currentKey) || currentList == null)
                {
                    if (currentList != null && currentList.Count > 0)
                        yield return new Grouping<TKey, TElement>(currentKey, currentList);
                    currentKey = key;
                    currentList = new List<TElement>();
                }
                currentList.Add(elem);
            }
            if (currentList != null && currentList.Count > 0)
                 yield return new Grouping<TKey, TElement>(currentKey, currentList);
        }
    }

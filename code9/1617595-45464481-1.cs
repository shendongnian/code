    public static class MyExtensions
    {
        /// <summary>
        /// Traverse a hierachy of items depths-first.
        /// </summary>
        /// <param name="source">The item source.</param>
        /// <param name="childrenGetter">Function to get the direct children of an item.</param>
        /// <returns>The items in <paramref name="source"/>, each recursively followed by it's descendants.</returns>
        public static IEnumerable<TSource> DepthFirst<TSource>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TSource>> childrenGetter)
        {
            foreach(var item in source)
            {
                yield return item;
                foreach (var descendant in childrenGetter(item).DepthFirst(childrenGetter))
                    yield return descendant;
            }
        }
    }

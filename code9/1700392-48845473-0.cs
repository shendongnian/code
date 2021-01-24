    public static class EnumerableExtensions
    {
        // Source: http://stackoverflow.com/questions/774457/combination-generator-in-linq#12012418
        private static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource item)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            yield return item;
            foreach (var element in source)
                yield return element;
        }
        public static IEnumerable<IEnumerable<TSource>> Permutations<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            var list = source.ToList();
            if (list.Count > 1)
                return from s in list
                       from p in Permutations(list.Take(list.IndexOf(s)).Concat(list.Skip(list.IndexOf(s) + 1)))
                       select p.Prepend(s);
            return new[] { list };
        }
    }

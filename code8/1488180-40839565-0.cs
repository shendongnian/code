        public static bool AtLeastTwo<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull(nameof(source));
            }
            using (IEnumerator<TSource> e = source.GetEnumerator())
            {
                e.MoveNext(); // Move past the first one
                return e.MoveNext(); // true if there is at least a second element.
            }
        }

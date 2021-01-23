    public static class IEnumerableExtender
    {
        public static bool StartsWith1<T>(this IEnumerable<T> source, IEnumerable<T> compare)
        {
            if (source.Count() < compare.Count())
            {
                return false;
            }
            using (var se = source.GetEnumerator())
            {
                using (var ce = compare.GetEnumerator())
                {
                    while (ce.MoveNext() && se.MoveNext())
                    {
                        if (!ce.Current.Equals(se.Current))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public static bool StartsWith2<T>(this IEnumerable<T> source, IEnumerable<T> compare) =>
            compare.Take(source.Count()).SequenceEqual(source);
        public static bool StartsWith3<T>(this IEnumerable<T> source, IEnumerable<T> compare)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (compare == null)
            {
                throw new ArgumentNullException(nameof(compare));
            }
            if (source.Count() < compare.Count())
            {
                return false;
            }
            return compare.SequenceEqual(source.Take(compare.Count()));
        }
        public static bool StartsWith4<T>(this IEnumerable<T> arr1, IEnumerable<T> arr2)
        {
            return StartsWith4(arr1, arr2, EqualityComparer<T>.Default);
        }
        public static bool StartsWith4<T>(this IEnumerable<T> arr1, IEnumerable<T> arr2, IEqualityComparer<T> comparer)
        {
            if (arr1.Count() < arr2.Count()) return false;
            for (var i = 0; i < arr2.Count(); i++)
            {
                if (!comparer.Equals(arr2.ElementAt(i), arr1.ElementAt(i))) return false;
            }
            return true;
        }
    }

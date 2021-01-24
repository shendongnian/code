    public static class LinqExtend {
        public static IEnumerable<T> FilterYear<T>(this IEnumerable<T> source, Func<int, IEnumerable<T>> callback, int year) {
            var items = callback(year);
            return items;
        }
    }

    static class Extensions {
        public static IEnumerable<T> TrimTrailing<T>(this IEnumerable<T> items,
                                                     Predicate<T> test) {
            var buf = new List<T>();
            foreach (var item in items) {
                if (test(item)) {
                    buf.Add(item);
                } else {
                    foreach (var buffered_item in buf) {
                        yield return buffered_item;
                    }
                    buf.Clear();
                    yield return item;
                }
            }
        }
    }

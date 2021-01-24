    public static class Extensions {
        public static T? StructFirstOrDefault<T>(this IEnumerable<T> items, Func<T, bool> predicate) where T : struct {
            return items.Where(predicate).Cast<T?>().FirstOrDefault();
        }
    }

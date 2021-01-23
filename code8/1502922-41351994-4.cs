    public static class EnumerableExt
    {
        public static S Fold<S, T>(this IEnumerable<T> self, S state, Func<S, T, S> folder) =>
            self.Any()
                ? Fold(self.Skip(1), folder(state, self.First()), folder)
                : state;
    }

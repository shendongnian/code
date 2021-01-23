    public static bool Any<T>(this IEnumerable<T> self) =>
        self.Fold(false, (state, item) => true);
    public static bool Exists<T>(this IEnumerable<T> self, Func<T, bool> predicate) =>
        self.Fold(false, (state, item) => state || predicate(item));
    public static bool ForAll<T>(this IEnumerable<T> self, Func<T, bool> predicate) =>
        self.Fold(true, (state, item) => state && predicate(item));
    public static IEnumerable<R> Select<T, R>(this IEnumerable<T> self, Func<T, R> map) =>
        self.FoldBack(Enumerable.Empty<R>(), (state, item) => map(item).Cons(state));
    public static IEnumerable<T> Where<T>(this IEnumerable<T> self, Func<T, bool> predicate) =>
        self.FoldBack(Enumerable.Empty<T>(), (state, item) => 
            predicate(item) 
                ? item.Cons(state)
                : state);

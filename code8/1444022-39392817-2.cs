    public static class TryExtensions
    {
        public static Try<U> Select<T, U>(this Try<T> self, Func<T, U> select) =>
            new Try<U>(() =>
            {
                var resT = self.Try();
                if (resT.IsFaulted) return new TryResult<U>(resT.Exception);
                return select(resT.Value);
            });
        public static Try<V> SelectMany<T, U, V>(
            this Try<T> self,
            

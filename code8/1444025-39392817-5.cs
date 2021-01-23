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
            Func<T, Try<U>> bind,
            Func<T, U, V> project ) =>
                new Try<V>(() =>
                {
                    var resT = self.Try();
                    if (resT.IsFaulted) return new TryResult<V>(resT.Exception);
                    var resU = bind(resT.Value).Try();
                    if (resU.IsFaulted) return new TryResult<V>(resT.Exception);
                    return new TryResult<V>(project(resT.Value, resU.Value));
                });
    }

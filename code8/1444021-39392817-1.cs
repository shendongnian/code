    public static class TryExtensions
    {
        public static TryResult<T> Try<T>(this Try<T> self)
        {
            try
            {
                if (self == null) return TryResult<T>.Bottom;
                return self();
            }
            catch (Exception e)
            {
                return new TryResult<T>(e);
            }
        }
        public static R Match<T, R>(this Try<T> self, Func<T, R> Succ, Func<Exception, R> Fail)
        {
            var res = self.Try();
            return res.IsFaulted
                ? Fail(res.Exception)
                : Succ(res.Value);
        }
    }

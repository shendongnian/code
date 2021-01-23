    public static class Retry
    {
        public static IRetryConfiguration Do(Action action)
        {
            return new ActionRetryConfiguration(action, 1, null);
        }
        public static IRetryConfiguration<TResult> Do<TResult>(Func<TResult> action)
        {
            return new FunctionRetryConfiguration<TResult>(action, 1, null, null);
        }
    }

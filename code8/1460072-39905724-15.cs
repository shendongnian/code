    public interface IRetryConfiguration : IRetryResult
    {
        IRetryConfiguration Times(int times);
        IRetryConfiguration Interval(TimeSpan interval);
    }
    public interface IRetryConfiguration<out TResult> : IRetryResult<TResult>
    {
        IRetryConfiguration<TResult> Times(int times);
        IRetryConfiguration<TResult> Interval(TimeSpan interval);
        IRetryConfiguration<TResult> Until(Function<TResult, bool> condition);
    }

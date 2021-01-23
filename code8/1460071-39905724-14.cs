    public interface IRetryResult
    {
        void Execute();
    }
    public interface IRetryResult<out TResult>
    {
        TResult Execute();
    }

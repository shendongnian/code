    public interface IResult
    {
        bool IsSuccessful { get; }
        ICollection<BrokenRule> BrokenRules { get; }
        bool HasNoPermissionError { get; }
        bool HasNoDataFoundError { get; }
        bool HasConcurrencyError { get; }
        string ErrorMessage { get; }
    }
    public interface IResult<T> : IResult
    {
        T Data { get; }
    }

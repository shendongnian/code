    internal class Result
        {
        internal bool IsFailure => !IsSuccess;
        internal bool IsSuccess { get; }
        internal string Error { get; }
        protected Result(bool isSuccess, string error) {
            IsSuccess = isSuccess;
            Error = error;
        }
        private Result(bool isSuccess) : this(isSuccess, null) { }
        internal static Result Fail(string error) => new Result(false, error);
        internal static Result<T> Fail<T>(string error) =>
            new Result<T>(default(T), false, error);
        internal static Result Ok() => new Result(true);
        internal static Result<T> Ok<T>(T value) => new Result<T>(value, true);
    }
    internal sealed class Result<T> : Result
        {
        internal T Value { get; }
        internal Result(T value, bool isSuccess) : this(value, isSuccess, null) { }
        internal Result(T value, bool isSuccess, string error) : base(isSuccess, error) {
            Value = value;
        }

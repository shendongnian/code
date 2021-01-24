    public class Result<T>
    {
        public Result(T value, bool success)
        {
            Value = value;
            Success = success;
        }
        public T Value { get; private set; }
        public bool Success { get; private set; }
    }

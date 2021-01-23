    class SomeEntity
    {
        public int Id { get; set; }
        public string Data { get; set; }
    }
    class FailedOperation<T>
    {
        public FailedOperation( T data, Exception error )
        {
            Data = data;
            Error = error;
        }
        public T Data { get; }
        public Exception Error { get; }
    }
    class OperationResult<TSource, TResult>
    {
        public IList<TResult> Succeded { get; set; }
        public IList<FailedOperation<TSource>> Failed { get; set; }
    }

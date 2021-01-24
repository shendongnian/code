    sealed class ResponseWrapper<T>
    {
        public ResponseWrapper(T response)
        {
            Value = response;
        }
        public T Value { get; set; }
    }

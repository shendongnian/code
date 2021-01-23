    [Serializable]
    class Result<T>
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public T Value { get; set; }
    }

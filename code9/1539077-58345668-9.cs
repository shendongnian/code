    class InvalidInputCustomException : Exception
    {
        public string InputExceptionType { get; set; }
        public InvalidInputCustomException(string inputExceptionType)
        {
            InputExceptionType = inputExceptionType;
        }
    }

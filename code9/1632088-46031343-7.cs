    public static class ResultsPair
    {
        public static ResultsPair<T> CreateSuccess<T>(T value) => Create(ResultsItem.Success(string.Empty), value);
        public static ResultsPair<T> CreateError<T>(ResultsItem result) => Create(result, default(T));
        
        public static ResultsPair<T> Create<T>(ResultsItem result, T value)
        {
            return new ResultsPair<T>(result, value);
        }
    }

    public class ResultsPair<T>
    {
        public T Value { get; set; }
        public ResultsItem Result { get; set; }
    
        public ResultsPair(ResultsItem result, T value)
        {
            Result = result;
            Value = value;
        }
    
        public static ResultsPair<T> Create(ResultsItem result, T value)
        {
            return new ResultsPair<T>(result, value);
        }
    }
    public class ResultsPair
    {
        public static ResultsPair<T> CreateSuccess<T>(T value) => ResultsPair<T>.Create(ResultsItem.Success(string.Empty), value);
        public static ResultsPair<T> CreateError<T>(ResultsItem result) => ResultsPair<T>.Create(result, default(T));
    }

    public class ResultsPair
    {
        public static ResultsPair<T> CreateSuccess<T>(T value) => ResultsPair<T>.Create(ResultsItem.Success(string.Empty), value);
        public static ResultsPair<T> CreateError<T>(ResultsItem result) => ResultsPair<T>.Create(result, default(T));
    }

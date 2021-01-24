    public class OperResult : OperResult<object> {
        public static OperResult<T> Success<T>(T data) {
            return OperResult<T>.Success(data);
        }
    }

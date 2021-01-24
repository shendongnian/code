    public class OperResult<T> {
        protected OperResult(T data) {
            this.Data = data;
        }
        public string ErrorCode { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }
        public bool Ok { get; private set; }
        public string IncidentNumber { get; private set; }
        public static OperResult<T> Success(T data) {
            return new OperResult<T>(data);
        }
    }
    public class OperResult : OperResult<object> {
        public OperResult(object data)
            : base(data) {
        }
        public static OperResult Success() {
            return new OperResult(new object());
        }
        public static OperResult<T> Success<T>(T data) {
            return OperResult<T>.Success(data);
        }
    }

    public class OperResult {
        protected OperResult(object data) {
            this.Data = data;
        }
        public string ErrorCode { get; protected set; }
        public string Message { get; protected set; }
        public object Data { get; protected set; }
        public bool Ok { get; protected set; }
        public string IncidentNumber { get; protected set; }
        public static OperResult Success(object data = null) {
            return new OperResult(data ?? new object());
        }
        public static OperResult<T> Success<T>(T data) {
            return new OperResult<T>(data);
        }
    }
    public class OperResult<T> : OperResult {
        public OperResult(T data)
            : base(data) {
        }
        public new T Data { get; protected set; }
    }

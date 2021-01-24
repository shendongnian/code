    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public object Paginator { get; set; }
        public T Data { get; set; }
    }

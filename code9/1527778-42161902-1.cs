    public class ApiResponse<TData> {
        public bool Success  { get; set; }
        public object Paginator { get; set; }
        public TData Data  { get; set; }
    }
    
    public class ApiResponse: ApiResponse<object> {
    }

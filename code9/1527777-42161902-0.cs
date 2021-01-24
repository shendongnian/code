    public class ApiResponseClass<T> {
        public bool Success  { get; set; }
        public object Paginator { get; set; }
        public T Data  { get; set; }
    }
    
    public class ApiResponseClass: ApiResponseClass<object> {
    }

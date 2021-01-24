    public class ApiResponse<T>
    {
        public bool Success { get; set;}
        public object Paginator { get; set;}
        public T Data { get; set; }
    }
    
    public class User
    {
        public string Name {get;set;}
        //Other properties
    }

    public class Response<T>
    {
        public bool Success {get;set;}
        public string ErrorMessage {get;set;}
        public List<T> Data {get;set;}
    }

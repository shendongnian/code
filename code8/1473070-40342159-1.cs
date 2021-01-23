    public class ResponseDTO<T>
    {
        public string Type {get;set;}
        public string Query {get;set;}
        public T Result {get;set;}
        public string Error {get;set;}
    }

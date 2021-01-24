    public class Response : Response<object> {
        public object Result { get; set; }
    }
    public class MultiResponse : Response<List<DeserializedResult>> {
        public List<DeserializedResult> Result { get; set; }
    }
    
    public class SingleResponse : Response<DeserializedResult> {
        public DeserializedResult Result { get; set; }
    }

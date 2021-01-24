    public class Response<T>
    {
        public int result_code { get; set; }
        public string result_message { get; set; }
        public T result_output { get; set; }
    }

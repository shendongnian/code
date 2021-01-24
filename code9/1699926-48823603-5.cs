    public class ApiResponse<T>
    {
        public T[] Data { get; set; }
        public String ErrorCode { get; set; }
        public Int32 ErrorNumber { get; set; }
        public String ErrorDesc { get; set; }
    }

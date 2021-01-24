    public class Result
    {
        public int ID { get; set; }
        public string Reference { get; set; }
        public int Asset { get; set; }
        public int Event { get; set; }
        public string DateEventStart { get; set; }
        public string DateEvent { get; set; }
    }
    public class RootObject<T>
    {
        public int Code { get; set; }
        public T Result { get; set; }
    }

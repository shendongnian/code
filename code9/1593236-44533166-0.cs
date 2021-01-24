    [DataContract]
    public class Response<T> {
        [DataMember]
        public T Person { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Email { get; set; }
    }

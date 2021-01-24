    [DataContract]
    public class ResponseDto
    {
        [DataMember(Name = "data", IsRequired = true)]
        public Data data { get; set; }
    }
    [DataContract]
    public class SecondResponseDto
    {
        [DataMember(Name = "results", IsRequired = true)]
        public List<Result> Results { get; set; }
    }

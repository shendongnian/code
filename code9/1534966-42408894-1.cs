    [DataContract]
    class LoginResult
    {
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string Message { get; set; }
    }

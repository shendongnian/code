     [Serializable]
    [DataContract]
    public class ApiResponse
    {
        [DataMember]
        public int code;
        [DataMember]
        public string message;
        [DataMember]
        public dynamic result;
    }

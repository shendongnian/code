    [DataContract]
    public class CustomUserSession: AuthUserSession
    {
        [DataMember]
        public string ZipCode { get; set; }
    }

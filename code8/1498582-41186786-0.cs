    [DataContract(Name = "book")]
    public class MyContract
    {
        [DataMember(Name = "UserName")]
        [Description("Name of the user")]
        public string UserName{ get; set; }
    
        // [.......]
    }

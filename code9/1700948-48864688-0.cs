    [DataContract]
    public class MyComplexType
    {
        public string TestStringNotVisible { get; set; } //this won't be displayed
        [DataMember]
        public bool TestBoolVisibleInWsdl { get; set; } = true;
        [DataMember]
        public string TestStringVisibleInWsdl { get; set; } = "Hello ";
    }

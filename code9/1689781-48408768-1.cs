    [Serializable]
    public class YourObjectClass
    {
        public string StringValue1 { get; set; }
        public string StringValue2{ get; set; }
        [XmlElement("YourOtherObjectClass")]
        public List<YourOtherObjectClass> OtherObjectClassList = new List<YourOtherObjectClass>();
    }
    [Serializable]
    public class YourOtherObjectClass
    {
        public string StringValue1 { get; set; }
    }

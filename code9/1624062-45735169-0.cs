    [AttributeUsage(AttributeTargets.Property)]
    public class XmlDescription : Attribute
    {
        public string Value { get; set; }
    }

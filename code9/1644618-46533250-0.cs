    public class RootObject
    {
        public string[] PostalAddress { get; set; }
        public bool ShouldSerializePostalAddress() { return PostalAddress != null && PostalAddress.Length > 0; }
    }

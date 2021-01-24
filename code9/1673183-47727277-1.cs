     public class JsonType : Attribute
    {
        private string _name;
        public JsonType(string name)
        {
            _name = name;
        }
        override
        public string ToString()
        {
            return _name;
        }
    }
    [JsonType("providerAccount")]
    public class RootObjectProvider
    {
        public ProviderAccount providerAccount { get; set; }
    }

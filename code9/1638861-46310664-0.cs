    class AbcDTO
    {
        public AbcDTO() { this.AdditionalData = new Dictionary<string, object>(); }
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        [JsonExtensionData]
        public Dictionary<string, object> AdditionalData { get; private set; }
    }

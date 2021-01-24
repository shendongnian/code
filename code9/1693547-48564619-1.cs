    public struct ExtString
    {
        private String Value
        {
            get;
            set;
        }
        [JsonConstructor]
        public ExtString([JsonProperty("$value")] String str)
        {
            this.Value = str;
        }

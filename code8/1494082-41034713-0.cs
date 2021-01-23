    public RootObject()
    {
        [JsonProperty("HasErrors")]
        public boolean HasErrors { get; set; }
        [JsonProperty("Limit")]
        public int Limit { get; set; }
        public IList<Results> Results { get; set; }
        //Etc...
    }

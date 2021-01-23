    public RootObject()
    {
        [JsonProperty("HasErrors")] //This will point to your JSON attribute 'HasErrors'
        public boolean Errors { get; set; } //Note that the name is different, but it will still deserialize.
        [JsonProperty("Limit")]
        public int Limit { get; set; }
        public IList<Results> Results { get; set; }
        //Etc...
    }

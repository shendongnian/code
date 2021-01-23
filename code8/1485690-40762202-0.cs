    [JsonProperty(PropertyName = "wc")]
    public int WordsCount { get; set; }
    
    [JsonProperty(PropertyName = "SoS")]
    public int SourceStartChar { get; set; }
    
    [JsonProperty(PropertyName = "SoE")]
    public int SourceEndChar { get; set; }
    
    [JsonProperty(PropertyName = "SuS")]
    public int SuspectedStartChar { get; set; }
    
    [JsonProperty(PropertyName = "SuE")]
    public int SuspectedEndChar { get; set; }

    public partial class Settings
    {
      [JsonProperty("id")]
      public int Id { get; set; }
      [JsonProperty("runTime")]
      public TimeSpan RunTime { get; set; }
      [JsonProperty("retryInterval")]
      public TimeSpan RetryInterval { get; set; }
      [JsonProperty("retryCutoffTime")]
      public TimeSpan RetryCutoffTime { get; set; }
      [JsonProperty("cjisUrl")]
      public string CjisUrl { get; set; }
      [JsonProperty("cjisUserName")]
      public string CjisUserName { get; set; }
      [JsonIgnore]
      public string CjisPassword { get; set; }
      [JsonProperty("importDirectory")]
      public string ImportDirectory { get; set; }
      [JsonProperty("exportDirectory")]
      public string ExportDirectory { get; set; }
      [JsonProperty("exportFilename")]
      public string ExportFilename { get; set; }
      [JsonProperty("jMShareDirectory")]
      public string JMShareDirectory { get; set; }
      [JsonIgnore]
      public string Database { get; set; }
    }

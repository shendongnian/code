    public class Value
    {
      [JsonProperty("odata.type")]
      public string odata_type { get; set; }
      [JsonProperty("odata.id")]
      public string odata_id { get; set; }
      [JsonProperty("odata.etag")]
      public string odata_etag { get; set; }
      [JsonProperty("odata.editLink")]
      public string odata_editLink { get; set; }
      public int Id { get; set; }
      public string Title { get; set; }
      public string Mesage { get; set; }
      public string Description { get; set; }
      public string Priority { get; set; }
      public int ID { get; set; }
    }
    public class Response
    {
       [JsonProperty("odata.metadata")]
       public string odata_metadata { get; set; }
       public List<Value> value { get; set; }
    }

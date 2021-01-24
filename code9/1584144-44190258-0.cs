    class Application
    {
        public DataModel dataModel { get; set; }
    }
    
    [JsonConverter(typeof(DataModelConverter))]
    class DataModel
    {
        public String id { get; set; }
    }

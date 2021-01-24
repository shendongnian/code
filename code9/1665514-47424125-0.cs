    public class ListOfValues
    {
        [JsonIgnore]
        public ObjectId Id { get; set; }
        
        public string ListName { get; set; }
        public List<Dictionary<string,object>> MetaData { get; set; }
    }

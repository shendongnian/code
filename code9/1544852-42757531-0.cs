    public class RootObject
     {
        [JsonProperty(PropertyName = "@odata.context")]
        public string context { get; set; }
        public List<Value> value { get; set; }
     }
    
    public class Value
     {
        [JsonProperty(PropertyName = "@odata.id")]
        public string dataId { get; set; }
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string ParentFolderId { get; set; }
        public int ChildFolderCount { get; set; }
        public int UnreadItemCount { get; set; }
        public int TotalItemCount { get; set; }
    
     }

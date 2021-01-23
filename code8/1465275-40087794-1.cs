    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public AddedInfo addedInfo { get; set; }
        [JsonIgnore]
        public int thisisinteresting { get { return addedInfo.thisisinteresting; } }
    }

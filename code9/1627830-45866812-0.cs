    var res = JsonConvert.DeserializeObject<RootObject>(json);
    public class Item
    {
        public int Id { get; set; }
        public Dictionary<string,string> Name { get; set; }
        public Dictionary<string, string> Value { get; set; }
    }
            
    public class RootObject
    {
        public Dictionary<string, Item> Attributes { get; set; }
    }

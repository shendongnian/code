    public class Partner
    {
        public string imageUrl { get; set; }
        public string webUrl { get; set; }
    }
    
    public class RootObject
    {
        public List<Partner> partners { get; set; }
    } 
........
    var result = JsonConvert.DeserializeObject<RootObject>(jsonObject);

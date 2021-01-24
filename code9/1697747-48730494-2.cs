    public class ItemClass
    {
        public string id { get; set; }
        public double valueItem { get; set; }
    }
    var objList =  JsonConvert.DeserializeObject<ItemClass>(json);

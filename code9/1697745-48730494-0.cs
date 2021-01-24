    public class ItemClass
    {
        public string id { get; set; }
        public string valueItem { get; set; }
    }
    var objList =  JsonConvert.DeserializeObject<ItemClass>(json);

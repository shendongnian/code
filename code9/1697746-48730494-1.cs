    public class ItemClass
    {
        public string id { get; set; }
        public string valueItem { get; set; }
        public double getValueItem()
        {
            return double.parse(this.valueItem);
        }
    }
    var objList =  JsonConvert.DeserializeObject<ItemClass>(json);

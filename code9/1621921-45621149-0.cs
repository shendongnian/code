    var list = JsonConvert.DeserializeObject<List<Item>>(json);
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Item
    {
        public Product product { get; set; }
    }

    public class Header
    {
        public List<List<Item>> bed_configurations { get; set; }
    }
    public class Item
    {
        public string type { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public int count { get; set; }
    }
    private static void getJSON()
    {
        List<Item> items = new List<Item>();
        items.Add(new Item() { type = "standard", code = 3, count = 1 });
        items.Add(new Item() { type = "custom", name = "Loft", count = 1 });
        Header ob = new Header();
        ob.bed_configurations = new List<List<Item>>() { items };
        string output = JsonConvert.SerializeObject(ob);
    }

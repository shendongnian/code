    public class PacksModel
    {
        public Dictionary<string, Dictionary<string, Item>> packs { get; set; }
    }
    public class Item
    {
        public string url { get; set; }
        public string name { get; set; }
    }
    // ......................................
    var obj = JsonConvert.DeserializeObject<PacksModel>(json);
    Console.WriteLine(obj.packs["category2"]["medium"].url);

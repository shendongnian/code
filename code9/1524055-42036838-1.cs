    public class Item
    {
        public string Key;
        public string Value;
    }
    
        List<Item> items = new List<Item>();
        
        items.Add(new Item { Key = "a", Value = "A Value" });
        items.Add(new Item { Key = "b", Value ="B Value" });
        
        items[1] = new Item { Key = "c", Value = "C value" };

    public string Key;
    public string Value;
}
    List<Item> items = new List<Item>();
    
    items.Add(new Item { "a", "A Value" });
    items.Add(new Item { "b", "B Value" });
    
    items[1] = new Item { "c", "C value" };

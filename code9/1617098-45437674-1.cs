    List<string> lines = File.ReadAllLines("btnSoda.text");
    List<Item> items = new List<Item>();
    
    foreach(string line in lines)
    {
        string[] parts = line.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
        string name = parts[0];
        int price = int.Parse(parts[1]);
        Item item = new Item(name, price);
        items.Add(item);
    }
    
    comboBox1.DataSource = items;

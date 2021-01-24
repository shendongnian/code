    class ViewModel
    {
        public List<List<Item>> ItemLists { get; private set; }
        public ViewModel()
        {
            string[] items = { "Intel procesor Core i7 6800K", "Intel procesor Core i5 7400", "AMD procesor Ryzen 7 1800X" };
            ItemLists = new List<List<Item>>();
            ItemLists.Add(new List<Item>());
            foreach (string item in items)
                ItemLists[0].Add(new Item(item));
        }
    }

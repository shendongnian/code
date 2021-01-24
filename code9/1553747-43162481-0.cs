    class Item
    {
        public string Name { get; set; }
        public Item(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }

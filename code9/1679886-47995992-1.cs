    public class MainWindowVM
    {
        public MainWindowVM()
        {
            ItemsList = new List<Group>();
            var items  = new List<Item>();
            items.Add(new Item("Item1")); 
            items.Add(new Item("Item2")); 
            items.Add(new Item("Item3"));
            //items.Add("Item4"); 
            //items.Add("Item5");
            ItemsList.Add(new Group()
            {
                Name = "List1",
                Items = items
            });
            items.Add(new Item("Item4"));
            ItemsList.Add(new Group()
            {
                Name = "List2",
                Items = items
            });
            items.Add(new Item("Item5"));
            ItemsList.Add(new Group()
            {
                Name = "List3",
                Items = items
            });
        }
        public List<Group> ItemsList { get; set; }
    }
   
    public class Group
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

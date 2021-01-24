    public abstract class Item
    {
        private static int nextId = 0; // Some Id-generator
        public Item()
        {
            this.Id = nextId++;
        }
        public int Id { get; set; } // Id to see the difference between the objects.
        public string Name { get { return this.GetType().Name + ":" + this.Id; } } // For Console..
    }
    public abstract class ItemWithChildren<TChildClass> : Item where TChildClass : new()
    {
        public ItemWithChildren()
        {
            this.Childs = new ObservableCollection<TChildClass>();
        }
        public ObservableCollection<TChildClass> Childs { get; set; }
        public TChildClass NewChildItem()
        {
            TChildClass newItem = new TChildClass();
            Childs.Add(newItem);
            return newItem;
        }
    }
    public class ItemA : ItemWithChildren<ItemB> { }
    public class ItemB : ItemWithChildren<ItemC> { }
    public class ItemC : Item { }
    public static void Test()
    {
        ItemA a = new ItemA();
        ItemB b = a.NewChildItem();
        b = a.NewChildItem();
        b = a.NewChildItem();
        ItemC c = b.NewChildItem();
        c = b.NewChildItem();
        c = b.NewChildItem();
        c = b.NewChildItem();
        Console.WriteLine(string.Join(", ", a.Childs.Select(x => x.Name)));
        Console.WriteLine(string.Join(", ", b.Childs.Select(x => x.Name)));
    }

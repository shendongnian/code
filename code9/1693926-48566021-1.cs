        // Master-class with business-logic or so..
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
        // Class with business-logic for items which can have children
        public abstract class ItemWithChildren<TChildClass> : Item where TChildClass : Item, new()
        {
            public ItemWithChildren()
            {
                this.Childs = new ObservableCollection<TChildClass>();
            }
            public ObservableCollection<TChildClass> Childs { get; set; }
            public Item NewChildItem()
            {
                TChildClass newItem = new TChildClass();
                Childs.Add(newItem);
                return newItem;
            }
            public List<Item> GetChildItemsTypeless()
            {
                return this.Childs.Select(s => (Item) s).ToList();
            }
        }
        // implementation of you concrete types..
        public class ItemA : ItemWithChildren<ItemB>, IItemWithChildren { }
        public class ItemB : ItemWithChildren<ItemC>, IItemWithChildren { }
        public class ItemC : Item { }
        // interface for managing children
        public interface IItemWithChildren
        {
            Item NewChildItem();
            List<Item> GetChildItemsTypeless();
        }
        public static void Test()
        {
            // Lets build some Items with an hierarchy
            ItemA a = new ItemA();
            ItemB b = (ItemB)a.NewChildItem(); // We cast here to explicit type to show that it's working.
            Item b2 = a.NewChildItem(); // Here we got our anonymous Item
            ItemC c = (ItemC)b.NewChildItem();
            Item c2 = b.NewChildItem();
            // Lets build an anonymous list - like your args-object
            List<Item> items = new List<Item>() {a, b, b2, c, c2};
            
            // some target for our new children..
            List<Item> allItems = new List<Item>();
            // let's add some children
            foreach (Item item in items)
            {
                allItems.Add(item);
                IItemWithChildren itemWithchildren = item as IItemWithChildren;
                if (itemWithchildren != null)
                    allItems.Add(itemWithchildren.NewChildItem());
            }
            Console.WriteLine(" - - - Items with their children - - -");
            foreach (Item item in allItems)
            {
                IItemWithChildren itemWithchildren = item as IItemWithChildren;
                Console.WriteLine(item.Name + (itemWithchildren != null ? ": " + String.Join(", ", itemWithchildren.GetChildItemsTypeless().Select(s => s.Name)) : ""));
            }
            Console.WriteLine(" - - - Items by hierarchy - - -");
            PrintItem(a);
        }
        public static void PrintItem(Item i, int level = 1)
        {
            Console.WriteLine(" ".PadRight(level*4) + i.Name);
            IItemWithChildren itemWithchildren = i as IItemWithChildren;
            if (itemWithchildren != null)
            {
                foreach (Item x in itemWithchildren.GetChildItemsTypeless())
                {
                    PrintItem(x, level + 1);
                }
            }
        }

    public class Item
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }
    public void test()
    {
        var list1 = new List<Item>(); // add items to list1 or maybe load from a database?
    
        var list2 = new ConcurrentBag<Item>();
    
        Parallel.ForEach(list1.ToList(), (item, state, arg3) =>
        {
            if (!list2.Any(x => x.Name == item.Name && x.Number == item.Number))
            {
                list2.Add(item);
            }
    
        });
                  
    }

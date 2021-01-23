    public class MyItem
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    static void Main(string[] args)
    {
        List<MyItem> items = new List<MyItem>
        {
            new MyItem
            {
                Name ="A",
                Id = 1,
            },
            new MyItem
            {
                Name = "B",
                Id = 2,
            }
        };
        var dynamicItems = items.Select(x => {
            dynamic myValue;
            if (x.Id % 2 == 0)
                myValue = new { Name = x.Name };
            else
                myValue = new { Name = x.Name, Id = x.Id };
            return myValue;
        }).ToList();
    }

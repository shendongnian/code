    class Program
    {
        // Create a Dictionary of Key type Predicate<MyStructure>, Predicate returns true or false - no need for a Func<bool>
        private static Dictionary<Predicate<MyStructure>, string> badRequests = new Dictionary<Predicate<MyStructure>, string>
        {
            [p => string.IsNullOrWhiteSpace(p.Name)] = "Name parameter cannot be empty or null string",
            [p => p.Items.Count == 2 /* <- This is important, as René pointed out in his answer */ && p.Items[0].Type == ItemsType.Green &&
                   p.Items[0].Id == "0020012321" && p.Items[1].Type == ItemsType.Red &&
                   p.Items[1].Id == "9023546547"
            ] = "could not be created with one with these types"
        };
        static void Main(string[] args)
        {
            // Initialize object
            MyStructure data = new MyStructure()
            {
                Name = "Test",
                DateTime = "2017-07-14T00:00:00.000Z",
                Items = new List<ItemsRequest>
                    {
                        new ItemsRequest() { Type = ItemsType.Green, Id = "0020012321" },
                        new ItemsRequest() { Type = ItemsType.Red, Id = "9023546547" }
                    }
            };
            // Call badRequests Dictionary with data to fetch Value
            string myString = badRequests.FirstOrDefault(p => p.Key.Invoke(data)).Value;
            Console.ReadKey();
        }
        public class MyStructure
        {
            public string Name { get; set; }
            public string DateTime { get; set; }
            public List<ItemsRequest> Items { get; set; }
        }
        public class ItemsRequest
        {
            public string Id { get; set; }
            public ItemsType Type { get; set; }
        }
        public enum ItemsType
        {
            Green, Red
        }
    }

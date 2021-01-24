    public class Header
        {
            public int Number { get; set; }
            public double Total { get; set; }
        }
    
        public class Item
        {
            public int Line { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }
    
        public class Source
        {
            public Header Header { get; set; }
            public List<Item> Items { get; set; }
        }
    
        public class Target
        {
            public int HeaderNumber { get; set; }
            public double Total { get; set; }
            public int Line { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var src = @"{""Header"":{ ""Number"" : 101, ""Total"" : 100.00},
    ""Items"" : [
    {""Line"" : 1, ""Description"": ""Item 1"", ""Price"" : 25.00, ""Quantity"" : 2},
    {""Line"" : 2, ""Description"": ""Item 2"", ""Price"" : 50.00, ""Quantity"" : 1}
    ]}";
    
                var srcObj = JsonConvert.DeserializeObject<Source>(src);
    
                var targetObj = srcObj.Items.Select(s => new Target()
                {
                    HeaderNumber = srcObj.Header.Number,
                    Total = srcObj.Header.Total,
                    Description = s.Description,
                    Line = s.Line,
                    Price = s.Price,
                    Quantity = s.Quantity
                });
                Console.WriteLine(JsonConvert.SerializeObject(targetObj));
                Console.ReadLine();
    
            }
        }

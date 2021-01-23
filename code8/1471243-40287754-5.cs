     public class Item { public int Price { get; set; } = 0; public string Name { get; set; } = ""; }
     static void Main(string[] args)
        {           
            var Collection = new List<Item>();
            var itemPrices = Collection.Select(item =>
            {
                var x = 10;
                var y = item.Price;
                return new { ItemName = item.Name, ItemPrice = x * y };
            }).ToList();
            itemPrices.ForEach(itemData =>
            {
                Console.WriteLine(itemData.ItemName + " " + itemData.ItemPrice.ToString());
            });
        }
    

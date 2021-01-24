    namespace ConsoleApplication7
    {
        internal class Program
        {
            private static void Main()
            {
                var groceries = new List<GroceryItem>();
                groceries.Add(new GroceryItem("Carrot", 23.57m, DateTime.Today));
            }
        }
    
        internal sealed class GroceryItem
        {
            public GroceryItem(string description, decimal price, DateTime expirationDate)
            {
                Description = description;
                Price = price;
                ExpirationDate = expirationDate;
            }
            public string Description { get; }
            public decimal Price { get; }
            public DateTime ExpirationDate { get; }
        }
    }

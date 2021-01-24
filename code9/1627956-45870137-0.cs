    class Program
    {
        public class InventoryItems
        {
            public string Id { get; set; }
        }
        static void Main(string[] args)
        {
            var items = new[]
            {
                new InventoryItems {Id = "One"},
                new InventoryItems {Id = "Two"},
                new InventoryItems {Id = "Three"},
            };
            
            var idsToDelete = string.Join(",", items.Select(x => "'" + x.Id + "'"));
            var deleteStatement = $"DELETE FROM InventoryItem WHERE Id IN ({idsToDelete})";
            Console.WriteLine($"TSQL - {deleteStatement}");
            Console.ReadLine();
        }
    }

    //Recursive method
     private static string GetParentPath( IEnumerable<Item> items , Item item )
        {
            if (item.ParentId.HasValue)
            {
                return GetParentPath(items, items.First(i => i.Id == item.ParentId)) + "/" + item.GenreName;
            }
            return item.GenreName;
        }
   
    var items = new Item[]
            {
                new Item {Id = 1, GenreName = "Test Genre 1", ParentId = null},
                new Item {Id = 2, GenreName = "Test Genre 2", ParentId = null},
                new Item {Id = 3, GenreName = "Test Genre 3", ParentId = 1},
                new Item {Id = 4, GenreName = "Test Genre 4", ParentId = 2},
                new Item {Id = 5, GenreName = "Test Genre 5", ParentId = 3}
            };
       
     // Linq query
            var result = from child in items
                      select new { Path = GetParentPath(items, child) };
    
     
        //Class used in example
     public class Item
        {
            public int Id { get; set; }
    
            public string GenreName { get; set; }
    
            public int? ParentId { get; set; }
        }

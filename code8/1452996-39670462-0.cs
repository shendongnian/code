    class Program
    {
        static void Main()
        {
            var allItems = GetAllItems();
    		var linqBooks = from item in allItems
	    	    where item.Name.ToLower().Contains("linq")
		    	select item;
    		foreach (var i in linqBooks)
	    	{
		    	var bookInfo = $"{i.Name}: {i.Price}";
			    Console.WriteLine(bookInfo);
		    }
        }
        static List<Category> GetAllCategories()
		{
			return new List<Category>()
			{
				new Category() { Id = 1, Name = "Books" },
				new Category() { Id = 1, Name = "Computers" }
			};
		}
        static List<Item> GetAllItems()
		{
			return new List<Item>()
			{
				new Item() { Id = 1, Name = "Embedded Linux", Category = 1, Price = 9.9 },
				new Item() { Id = 1, Name = "LINQ In Action", Category = 1, Price = 36.19 },
				new Item() { Id = 1, Name = "C# 6.0 and the .NET 4.6 Framework", Category = 1, Price = 40.99 },
				new Item() { Id = 1, Name = "Thinking in LINQ", Category = 1, Price = 36.99 }
			};
		}
    }
    public class Item
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int Category { get; set; }
	}
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

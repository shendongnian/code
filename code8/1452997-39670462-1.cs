    class Program
    {
        static void Main()
        {
            var allItems = GetAllItems();
    		var groups = from item in allItems
				group item by item.Category
				into newGroup
				select newGroup;
    		foreach (var group in groups)
			{
				Console.WriteLine($"\nCategory: {group.Key}");
				foreach (var item in group)
				{
					Console.WriteLine($"{item.Name}: {item.Price}");
				}
			}
			Console.ReadLine();
        }
        static List<Category> GetAllCategories()
		{
			return new List<Category>()
			{
				new Category() { Id = 1, Name = "Programming Books" },
				new Category() { Id = 2, Name = "Fiction Books" }
			};
		}
        static List<Item> GetAllItems()
		{
			return new List<Item>()
				{
					new Item() { Id = 1, Name = "Embedded Linux", Category = 1, Price = 9.9 },
					new Item() { Id = 2, Name = "LINQ In Action", Category = 1, Price = 36.19 },
					new Item() { Id = 3, Name = "C# 6.0 and the .NET 4.6 Framework", Category = 1, Price = 40.99 },
					new Item() { Id = 4, Name = "Thinking in LINQ", Category = 1, Price = 36.99 },
					new Item() { Id = 5, Name = "The Book Thief", Category = 2, Price = 7.99 },
					new Item() { Id = 6, Name = "All the Light We Cannot See", Category = 2, Price = 16.99 },
					new Item() { Id = 7, Name = "The Life We Bury", Category = 2, Price = 8.96 }
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

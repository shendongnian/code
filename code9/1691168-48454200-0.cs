	public class Program
	{
		public static void Main()
		{
			var items = new List<Item>
			{
				new Item{ Id = 1, Name = "Machine" },
				new Item{ Id = 3, Id_Parent = 1,  Name = "Machine1"},
				new Item{ Id = 5, Id_Parent = 3,  Name = "Machine1-A", Number = 2, Price = 10 },
				new Item{ Id = 9, Id_Parent = 3,  Name = "Machine1-B", Number = 4, Price = 11 },
				new Item{ Id = 100,  Name = "Item" } ,
				new Item{ Id = 112,  Id_Parent = 100, Name = "Item1", Number = 5, Price = 55 }
			};
			
			foreach(var item in items)
			{
				Console.WriteLine("{0} {1} $" + GetSum(items, item.Id).ToString(), item.Name, item.Id);
			}
			
		}
		
		public static int GetSum(IEnumerable<Item> items, int id)
		{
			// add all matching items
			var itemsToSum = items.Where(i => i.Id == id).ToList();
			var oldCount = 0;
			var currentCount = itemsToSum.Count();
			// it nothing was added we skip the while
			while (currentCount != oldCount)
			{
				oldCount = currentCount;
				// find all matching items except the ones already in the list
				var matchedItems = items
					.Join(itemsToSum, item => item.Id_Parent, sum => sum.Id, (item, sum) => item)
					.Except(itemsToSum)
					.ToList();
				itemsToSum.AddRange(matchedItems);
				currentCount = itemsToSum.Count;
			}
			
			return itemsToSum.Sum(i => i.Price);
		}
		
		public class Item
		{
			public int Id { get; set; }
			public int Id_Parent { get; set; }
			public int Number { get; set; }
			public int Price { get; set; }
			public string Name { get; set; }
		
		}
	}

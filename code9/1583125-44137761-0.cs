	void Main()
	{
		var query = new myViewModel();
		query.myObjects.FirstOrDefault(x => x.Name == "Test").Amount = 99;	
		query.Dump();
	}
	
	// Define other methods and classes here
	public class objectX
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Amount { get; set; }
	}
	
	public class myViewModel
	{
	
		public int Id { get; set; }
		public List<objectX> myObjects { get; set; }
		
		public myViewModel()
		{
			myObjects = new List<UserQuery.objectX>();
			myObjects.Add(new objectX { Amount = 100, Id = 1, Name = "ABC" });
			myObjects.Add(new objectX { Amount = 200, Id = 2, Name = "Test" });
			myObjects.Add(new objectX { Amount = 300, Id = 3, Name = "GHI" });
		}
	
	}

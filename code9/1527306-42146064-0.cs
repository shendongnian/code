    public static void Main()
	{
		var items = init();
		items.RemoveAll(x => !items.Any(y => y.ParentId == x.Id) == true && x.IsLastItem == false);			
		
	}
	
	public static List<Item> init()
	{			
		return new List<Item>
		{
			new Item
			{
				Id = 1,
				ParentId = 0,
				Content = "item1"
			},
				new Item
			{
				Id = 2,
				ParentId = 1,
				Content = "item2"
			},
				new Item
			{
				Id = 3,
				ParentId = 1,
				Content = "item3",
				IsLastItem = true
			},
				new Item
			{
				Id = 4,
				ParentId = 1,
				Content = "item4"
			},
				new Item
			{
				Id = 5,
				ParentId = 2,
				Content = "item5"
			},
				new Item
			{
				Id = 6,
				ParentId = 5,
				Content = "item6"
			},
				new Item
			{
				Id = 7,
				ParentId = 5,
				Content = "item7"
			},
				new Item
			{
				Id = 8,
				ParentId = 6,
				Content = "item8"
			},
				new Item
			{
				Id = 9,
				ParentId = 8,
				Content = "item9",
				IsLastItem = true
			}
		};		
	}

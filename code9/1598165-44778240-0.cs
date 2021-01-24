	private Random random = new Random();
	
	public MainPageViewModel()
	{
		/* Populate `items` */
		
		items =
			items
				.Take(1)
				.Concat(items.Skip(1).Take(items.Count() - 2).OrderBy(x => random.Next()))
				.Concat(items.Skip(items.Count() - 1))
				.ToList();
	}

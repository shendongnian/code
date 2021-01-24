	public void Insert(Entity e)
	{
		switch (e)
		{
			case Person p:
				Console.WriteLine("Insert Person");
				break;
			case City c:
				Console.WriteLine("Insert City");
				break;
			
			default:
				Console.WriteLine("<other>");
				break;
		}
	}

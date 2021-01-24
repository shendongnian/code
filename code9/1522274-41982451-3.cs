	public static void MyMethod(int page, string city, ref int citySum)
	{
		for(int i = 0; i < 50; i++)
		{
			citySum++;
		}
		if(page < 15)
		{
			MyMethod(page + 1, city, ref citySum); 
		}
	}

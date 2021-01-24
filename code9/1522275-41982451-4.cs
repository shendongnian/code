	public static int MyMethod(int page, string city)
	{
		int citySum = 0;
		
		for(int i = 0; i < 50; i++)
		{
			citySum++;
		}
		if(page < 15)
		{
			citySum += MyMethod(page + 1, city); 
		}
		
		return citySum;
	}

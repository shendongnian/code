	public int MyMethod(int page, string city, int citySum = 0)
	{
		//for (int i = 0; i < 50; i++)
		//{
		//	citySum++;
		//}
		
		citySum += 50;
		if (page < 15)
		{
			return MyMethod(page + 1, city, citySum);
		}
		
		return citySum;
	}

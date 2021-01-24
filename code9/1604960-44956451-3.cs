	public void HotDog()
	{
		if (DateTime.Now.Hour < 12)
		{
			Console.WriteLine("Morning");
			return;
		}
		
		Console.WriteLine("Not morning");
	}

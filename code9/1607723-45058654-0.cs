	public static void Main()
	{
		Task t = LongOP1();
        //  Do other stuff here...
		t.Wait();
	}
	
	public static async Task LongOP1()
	{
		long x = 0;
		
		await Task.Run(() =>
					   {
						   for (int i = 0; i <= 10000; i++)
						   {
							   for (int j = 0; j <= 10000; j++)
							   {
								   x += i + j;
							   }
						   }
					   });         
	}	

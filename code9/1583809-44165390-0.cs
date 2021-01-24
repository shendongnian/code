	class Test
	{
		static void Main()
		{
			Test.Run(null);
			Test.Run(new Test());
		}
	
		int value = 1;
	
		public static void Run(Test test)
		{
			try
			{
				int i = test.value;
				System.Console.WriteLine("The value is:" + i);
			}
			catch (System.NullReferenceException e)
			{
                System.Console.WriteLine(e.Message + "was handled.");
			}
		}
	}

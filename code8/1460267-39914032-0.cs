    static void Main(string[] args)
		{
			Task.Run(() => function1());
			Task.Run(() => function2());
		}
		private static void function2()
		{
			//throw new NotImplementedException();
		}
		private static void function1()
		{
			while (true)
			{
			}
		}

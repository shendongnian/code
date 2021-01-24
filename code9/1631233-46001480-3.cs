    class MyClass
	{
		[MyAttribute(PreAction = "Handler1", PostAction = "Handler2")]
		public void DoSomething()
		{
			
		}
		public static void Handler1()
		{
			Console.WriteLine("Pre");
		}
		public static void Handler2()
		{
			Console.WriteLine("Post");
		}
	}

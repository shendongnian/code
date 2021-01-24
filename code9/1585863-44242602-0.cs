    class SomeClass
	{
		private static class SomePrivateClass
		{
			public static void AddtwoNum(int num1, int num2)
			{
				//do some stuff here
			}
		}
		class SomePublicClass
		{
			public void InteractWithSomePrivateClass()
			{
				SomePrivateClass.AddtwoNum(1,2); //no problem
			}
		}
	}

    class SomeClass
	{
		private static class SomePrivateClass
		{
			public static int AddtwoNum(int num1, int num2)
			{
                return num1 + num2;
			}
		}
		class SomePublicClass
		{
            private int x = SomePrivateClass.AddtwoNum(1, 2);
			public void InteractWithSomePrivateClass()
			{
				SomePrivateClass.AddtwoNum(1,2); //no problem
			}
		}
	}

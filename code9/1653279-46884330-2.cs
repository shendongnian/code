		// With a "new()" contraint on U
		namespace ConsoleApp3
		{    
			class MyClass<T, U>
				where T : Something
				where U : AnOperation<Something>, new()
			{
				public U GetAnOperationOfSomething()
				{			
					U anOperation = new U();
					return anOperation; 
				}
			}
			public class Something
			{
			}
			public class AnOperation<T>
				where T : Something
			{
			}
		}

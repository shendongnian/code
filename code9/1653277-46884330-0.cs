		// With only one type of operation
		namespace ConsoleApp2
		{    
			class MyClass<T> where T : Something        
			{
				public AnOperation<T> GetAnOperationOfSomething()
				{
					AnOperation<T> anOperation = new AnOperation<T>();
					return anOperation; 
				}
			}
			public class Something
			{
			}
			public sealed class AnOperation<T>
				where T : Something
			{
			}
		}

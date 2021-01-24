		// With a factory for operations
		namespace ConsoleApp1
		{    
			class MyClass<T, U>
				where T : Something
				where U : AnOperation<Something>
			{
				private readonly Func<T, U> operationMaker;
					
				public MyClass(Func<T, U> operationMaker)
				{
					this.operationMaker = operationMaker;			
				}
					
				public U GetAnOperationOfSomething(T something)
				{			
					U anOperation = operationMaker(something);
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

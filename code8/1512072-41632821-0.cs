    using System;
	namespace StackOverflowInterfaces
	{
		class Item { }
		interface IFruit
		{
			void ExampleMethod();
		}
		class Apple : Item, IFruit
		{
			public void ExampleMethod()
			{
				throw new NotImplementedException();
			}
		}
		class MainClass
		{
			public static void Main()
			{
				Item exampleItem = new Apple();
				// exampleItem.ExampleMethod(); -- DOES NOT WORK, because Item does not implement IFruit
				(exampleItem as IFruit).ExampleMethod();
				(exampleItem as Apple).ExampleMethod();
				IFruit exampleFruit = new Apple();
				exampleFruit.ExampleMethod();
				Apple exampleApple = new Apple();
				exampleApple.ExampleMethod();
			}
		}
	}

	using System;
	namespace Test1
	{
		class Program
		{
			static void Main(string[] args)
			{
				var test = new TestClass();
				test.AddElement(new Element());
				Console.WriteLine(test.HowMuch());
			}
		}
	}

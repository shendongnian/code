	using System;
	
	public class TestClass
	{
		private delegate void TestDelegate();
		static TestDelegate testDelegate;    //<-- static
	
		static TestClass()                   //<-- static
		{
			testDelegate = new TestDelegate(MyMethod);
		}
	
		public static void Testit()
		{
			testDelegate();
		}
	
		private static void MyMethod()
		{
			Console.WriteLine("Foobar");
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Hello World");
			TestClass.Testit();
		}
	}

	using System;
	
	public class TestClass
	{
		private delegate void TestDelegate();
		TestDelegate testDelegate;
	
		public TestClass()
		{
			testDelegate = new TestDelegate(MyMethod);
		}
	
		public void Testit()   
		{
			testDelegate();
		}
	
		private void MyMethod()
		{
			Console.WriteLine("Foobar");
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Hello World");
			var t = new TestClass();
			t.Testit();   //<-- non-static
		}
	}

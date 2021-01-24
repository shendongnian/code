	public class MyClass 
	{
		const string MyStringFormat = "hello {0} world {1}";	
		public static string WriteMessage(int a, int b)
		{
			Console.WriteLine(MyStringFormat, a, b);
		}
	}

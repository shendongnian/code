	public class Program
	{
		public static void Main()
		{
			var c = new MyClass();
			typeof(MyClass)
				.GetMethod(nameof(c.MyClassMethod))
				.GetCustomAttributes(true)
				.OfType<HelloWorldAttribute>()
				.First()
				.OnBeforeExecute();
			c.MyClassMethod("Main call");
		}
	}

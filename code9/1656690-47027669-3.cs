	public class Program
	{
		public static void Main()
		{
			var c = new MyClass();
			typeof(MyClass)
				.GetMethod("MyClassMethod")
				.GetCustomAttributes(true)
				.OfType<HelloWorldAttribute>()
				.First()
				.MyAttributeMethod();
			c.MyClassMethod("Main call");
		}
	}

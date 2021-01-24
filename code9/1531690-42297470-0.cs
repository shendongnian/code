	[AttributeUsage(AttributeTargets.All)]
	public class MyAttribute : Attribute
	{
		public string TestValue { get; set; }
	}
    [MyAttribute(TestValue = "Hello World!"]
    public class MyClass{}

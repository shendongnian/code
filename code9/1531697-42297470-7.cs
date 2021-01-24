	[AttributeUsage(AttributeTargets.All)]
	public class MyAttribute : Attribute
	{
		public string TestValue { get; set; }
	}
    [My(TestValue = "Hello World!")]
    public class MyClass{}

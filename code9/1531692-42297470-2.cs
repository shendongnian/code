	[AttributeUsage(AttributeTargets.All)]
	public class MyAttribute : Attribute
	{
		public string TestValue { get; set; }
        public MyAttribute(int arg)
        {}
	}
    [MyAttribute(42, TestValue = "Hello World!"]
    public class MyClass{}

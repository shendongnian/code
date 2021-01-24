	[AttributeUsage(AttributeTargets.All)]
	public class MyAttribute : Attribute
	{
		public string TestValue { get; set; }
        public MyAttribute(int arg)
        {}
	}
    [My(42, TestValue = "Hello World!"]
    public class MyClass{}

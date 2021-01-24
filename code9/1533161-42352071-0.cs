	public static void Main()
	{
		var myType = new MyType();
		Console.WriteLine(myType.one + " " + myType.two);
		Console.WriteLine("before");
		myType = SetAllFieldsAsDefault(myType) as MyType;
		Console.WriteLine("after");
		Console.WriteLine(myType.one + " " + myType.two);
	}
	class MyType {
		internal double one = -1.1;
		internal string test = "hi";
		internal double two = 3.3;
	}

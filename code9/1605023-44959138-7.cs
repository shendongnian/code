	public static void Main()
	{
        // Compilation error: Cannot convert lambda expression to type 'object' because it is not a delegate type.
        // You'd need to use: MyMethod(new Func<bool>(() => true));
		MyMethod(() => true);
	}
	
	public static void MyMethod(object o) { }

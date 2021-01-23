	public object SomeLocalMethod() // Must return either `dynamic` over `object`
	{
		var myAnonClass = new { X = 1, Y = "Hello" };
		Console.WriteLine(myAnonClass.Y); // Prints "Hello";
		return myAnonClass;
	}
	
	void Main()
	{
		object tryLookAtAnon = SomeLocalMethod(); // No access to "X" or "Y" variables here.
	}
	

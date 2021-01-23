	void Main()
	{
		dynamic tryLookAtAnon = SomeLocalMethod();
		Console.WriteLine(tryLookAtAnon.X); // prints 1
	}
	
	public dynamic SomeLocalMethod() 
	{
		var myAnonClass = new { X = 1, Y = "Hello" };
		Console.WriteLine(myAnonClass.Y); // Prints "Hello";
		return myAnonClass;
	}

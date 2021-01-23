	public static void Foo(this Object bar)
	{
        // assignment
		bar = new ...();
		
		// here you're NOT calling Baz() on the object passed into the method
		bar.Baz();
	}

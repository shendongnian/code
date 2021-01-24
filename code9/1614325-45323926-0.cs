    void Main()
    {
    	Console.WriteLine(Foo()); // Prints 5
    }
    
    public static int Foo()
    {
    	return _();
        // declare the body of _()
    	int _()
    	{
    		return 5;
    	}
    }

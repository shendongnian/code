    void Main()
    {
    	int local = 0;
    
    	Foo(() => { local = 55; });
    	Console.WriteLine(local);
    }
    
    // Define other methods and classes here
    public static void Foo(Action bar)
    {
    	bar?.Invoke();
    }

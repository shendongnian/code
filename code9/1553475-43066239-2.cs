    void Main()
    {
    	int local = 0;
    
    	Foo(() => { local = 55; });
    	Console.WriteLine(local);
    }
    
    public static void Foo(Action bar)
    {
    	bar?.Invoke();
    }

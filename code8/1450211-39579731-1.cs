    void Main()
    {
    	var foo = FooFactory.Create();
    	var cached = foo.Bar.Baz;
    	Console.WriteLine(cached.One);
    	Console.WriteLine(cached.Two);
    	Console.WriteLine(cached.BothPopulated());
    	
    	var fooTwo = FooFactory.Create();
    	Console.WriteLine(fooTwo.Bar.Baz.One);
    	Console.WriteLine(fooTwo.Bar.Baz.Two);
    	Console.WriteLine(fooTwo.Bar.Baz.BothPopulated());
    }

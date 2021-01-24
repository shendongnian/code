    class SomeValue
    {
    	public string Foo { get; set; }
    
    	public int Code { get; set; }
    }
    
    static SomeValue ExampleFunction(string input)
    {
    	return new SomeValue
    	{
    		Foo = input,
    		Code = 1,
    	};
    }
    
    static void Main(string[] args)
    {
        // ...
    	SomeValue val = null;
    	switch (Type)
    	{
    		case 0: val = ExampleFunction(foo0); break;
    		case 1: val = ExampleFunction(foo1); break;
    		case 2: val = ExampleFunction(foo2); break;
    	}
    }

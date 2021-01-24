    var test = new C(1, 2);
    }
    
    class A
    {
    
    	public int a;
    	public int b;
    	public A(int x, int y)
    	{
    		a = x;
    		b = y;
    
    		Console.WriteLine("A");
    	}
    }
    
    class B : A
    {
    
    	public int d;
    	public int e;
    	public B(int x, int y) : base(x, y)
    	{
    		d = x;
    		e = y;
    		Console.WriteLine("B");
    	}
    }
    
    class C : B
    {
    
    	public C(int x, int y) : base(x, y)
    	{
    		Console.WriteLine("C");
    	}

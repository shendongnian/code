    abstract class C
    {
        public C()
    	{
    		Console.WriteLine("C()");
    	}
    }
    
    abstract class B : C
    {
    	public B()
    	{
    		Console.WriteLine("B()");
    	}
    }
    
    class A : B
    {
    }
    
    void Main()
    {
    	A a = new A();
    }

    public class MyTest
    {
    	public virtual void Test()
    	{
    		Console.WriteLine("Hi");
    	}
    }
    
    public class MyInterceptor : IInterceptor
    {
    	public void Intercept(IInvocation invocation)
    	{
    		Console.WriteLine("Was here");
    		invocation.Proceed();
    	}
    }
    
    void Main()
    {
    	ProxyGenerator g = new ProxyGenerator();
    	var t = g.CreateClassProxy<MyTest>(new MyInterceptor());
    	t.Test();
    }

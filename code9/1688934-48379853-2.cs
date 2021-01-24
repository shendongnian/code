    using System;
    
    public class a
    {
    	public virtual object s(int a)
    	{
    		return a + 1;
    	}
    }
    
    public class b : a
    {
    	public virtual object[] s(int a)
    	{
    		var arr = new object[]{a + 2};
    		return arr;
    	}
    }
    
    public class c : b
    {
    	private a A = new a();
    	private b B = new b();
    	public c()
    	{
    		print(2);
    	}
    
    	public void print(int a)
    	{
    		var result = A.s(1);
    		Console.WriteLine("result : " + result);
    		var resultB = B.s(1);
            //or resultB = base.s(1);
    		foreach (var r in resultB)
    		{
    			Console.WriteLine("result B : " + r);
    		}
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		c C = new c();
    	}
    }

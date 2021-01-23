    using System;
     
    public class Test
    {
    	static int Fib(int n) {
    		return (n < 2)? n : Fib(n - 1) + Fib(n - 2);
    	}
    	public static void Main()
    	{
    		Console.Write(Fib(10));
    	}
    }

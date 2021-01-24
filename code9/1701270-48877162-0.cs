    using System;
    using System.Threading;				
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		
    		ThreadStart s = () => Console.WriteLine("In s: {0}", Thread.CurrentThread.ManagedThreadId);
    		
    		Console.WriteLine("Before s.Invoke: {0}", Thread.CurrentThread.ManagedThreadId);
    		
    		s.Invoke();
    		
    		Console.WriteLine("After s.Invoke: {0}", Thread.CurrentThread.ManagedThreadId);
    	}
    }

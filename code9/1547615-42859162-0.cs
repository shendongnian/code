    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    		int[] b = a;
    		ref int a1 = ref a[1];
    		
    		Array.Resize(ref a, 5);
    		
    		a1 = 100;
    		Console.WriteLine(a[1]); // new
    		Console.WriteLine(b[1]); // original
            Console.WriteLine(ReferenceEquals(a, b));
    	}
    }

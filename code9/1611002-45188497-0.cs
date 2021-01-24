    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<int> list = Enumerable.Range( 0, 6 ).ToList();
    	 	list.Shuffle();
    		int a = list[0];
    		int b = list[1];
    		int c = list[2];
    		Console.WriteLine( a );
    		Console.WriteLine( b );
    		Console.WriteLine( c );
    	}   	
    		
    }
    
    public static class ListShuffler
    {
    	private static Random rng = new Random();
    	public static void Shuffle<T>(this IList<T> list)
    	{
    		int n = list.Count;
    		while (n > 1)
    		{
    			n--;
    			int k = rng.Next(n + 1);
    			T value = list[k];
    			list[k] = list[n];
    			list[n] = value;
    		}
    	}
    }

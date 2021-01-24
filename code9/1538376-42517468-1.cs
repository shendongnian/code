    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	// Partition n into m summands
    	static IEnumerable<IEnumerable<int>> Partitions(int n, int m)
    	{
		  // There is no partition of n into zero summands for any value of n other than zero.
		  // Otherwise, give the partitions that begin with 0, 1, 2, ... n.
		  if (m == 0) 
		  {
			if (n == 0)
		      yield return Enumerable.Empty<int>();
	      }
		  else 
		  {
			for (int nn = 0; nn <= n; ++nn)
				foreach(var p in Partitions(n - nn, m - 1))
					yield return (new[] { nn }).Concat(p);
		  }
    	}
    	
    	public static void Main()
    	{
            // Divide up six points into four buckets:
    		var partitions = Partitions(6, 4).ToArray();
    		// Now choose a random member of partitions, and 
            // add one to each element of that sequence. Now
            // you have ten points total, and every possibility is 
            // equally likely.
    		// Let's visualize the partitions:
    		foreach(var p in partitions)
    			Console.WriteLine(string.Join(",", p));
    		
    	}
    }

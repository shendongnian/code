    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var rnd = new Random();
    		var rndGen = new UniqueRandomGenerator(rnd);
    		
    		Console.WriteLine("Next random values from 1 to 5:");
    		for (int i = 1; i <= 5; i++) {
    			var next = rndGen.GetNext(1, 6);
    			Console.WriteLine(next);
    		}
    	}
    	
    	class UniqueRandomGenerator
    	{
    		readonly Random _rnd;
    		readonly HashSet<int> _generated;
    		readonly static int MAX_ITER_WHILE_GET_NEXT_RND = 100;
    		
    		public UniqueRandomGenerator(Random rnd) 
    		{
    			_rnd = rnd;
    			_generated = new HashSet<int>();
    
    		}
    		
    		public int GetNext(int lower, int upper) {
    			int next;
    			int i = 0;
    			do {
    				next = _rnd.Next(lower, upper);
    				i++;
    				if (i > MAX_ITER_WHILE_GET_NEXT_RND)
    					throw new InvalidOperationException("Exceed iter limit!");
    			}
    			while (_generated.Contains(next));
    			_generated.Add(next);
    			return next;
    		}
    	}
    }

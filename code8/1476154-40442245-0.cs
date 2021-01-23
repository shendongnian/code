    using System;
	using System.Linq;
	using System.Collections;
	
	class MainClass {
		
	  public static void Main (string[] args) {
	  	// table dimension (assumes a square)
	  	var dim = 10;
		var table = new int?[dim, dim];
	  	
	  	// 100 integers: 0..99
	  	var queue = new Queue(Enumerable.Range(0, dim * dim).ToList<int>());
	    var rng = new Random();
	
	    
	    int x = dim / 2, y = dim / 2;
	    
	    // Acceptable shuffle? As long as the queue has anything in it, try to place the next number
		while(queue.Count > 0) {
			x = rng.Next(dim);  // still using random, not great! :(
		    y = rng.Next(dim);
		    
		    if(table[x,y] == null)
				table[x,y] = (int)queue.Dequeue();
		}
		
		// print output so I know I'm not crazy
		for(var i = 0; i < dim; i++) {
			Console.Write("Row {0}: [", i);
			for(var j = 0; j < dim; j++) {
				Console.Write("{0,4}", table[i,j]);
			}
			Console.WriteLine("]");
		}
	  }
	}
	      

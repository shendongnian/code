    using System.Collections.Generic; 
    public class Program
    {
	
    	static int foo()
	    {
		    var list = new List<int> { 1, 2, 3, 4 };
    		int ret = 5;
	    	bool keepGoing = true;
		    list.ForEach(each =>
					 {
						if (!keepGoing)
							 return;
						 if (each>2)
						 {
							ret=each;
							keepGoing = false;
							return;
						 }
					 
						 System.Console.WriteLine(each);
						 
					 });
	    	return ret;
    	}
	    public static void Main(string[] args)
    	{
	    	var i = foo();
		    System.Console.WriteLine("i: " + i);
		
	    }
    }

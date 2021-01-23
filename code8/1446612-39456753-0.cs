    public class Program
    {
	    public static void Main()
    	{
	    	Program p = new Program();
		    if (p) {
    			//prints 'calling true operator'
	    	}
    	}
	
	    public static bool operator true(Program p) {
		    Console.WriteLine("calling true operator");
    		return true;
    	}
	
	    public static bool operator false(Program p) {
		    Console.WriteLine("calling false operator");
    		return false;
	    }
		
    }

    public static void DoWork()
    	{
    		for (int i = 0; i < 10; i++)
    		{
    			Console.WriteLine(i);
    		}
    		{ 
              // adding this block will remove the compiler error, 
              // and yes you can use the same variable name in the same 
              // method but you need to help the compiler that each 
              // variable usuage is under its own block.
    			int i = 777; // Not compiler error anymore
    			Console.WriteLine(i);
    		}
    	}

    using System;
    //https://stackoverflow.com/questions/46209099/multiplication-table-using-two-nested-loops-but-i-am-getting-an-error
    
    public class Program
    {
    	public static void Main()
    	{
    		for (int i = 0; i <= 9; i++)
    		{
    			if (i == 0)
    			{
    				Console.Write("*\t|\t");
    			}
    			else
    			{
    				
    				Console.Write(i + "\t|\t");
    			}
    
    			for (int j = 1; j <= 9; j++)
    			{
    				if (i > 0)
    					if(j*i>9)
    						Console.Write(i * j + "\t");
    					else
    						Console.Write(i * j + " \t");
    				else
    					Console.Write(j + "\t ");
    			}
    
    			Console.Write("\n");
    			if (i == 0)
    			{
    				Console.Write("\n");
    				for (int k = 0; k <= 10; k++)
    				{
    					if(k>2)
    						Console.Write(" -\t");
    					else
    						Console.Write("-\t");
    				}
    
    				Console.Write("\n");
    			}
    
    			Console.Write("\n");
    		}
    	
    	}
    }

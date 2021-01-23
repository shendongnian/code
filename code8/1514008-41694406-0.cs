    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var sortarry = new[] {4, 6, 4, 7, 8, 3};
    
                int best = -1;
                for(int i = 0; i < 6; i++)
                {
                    var cursel = sortarry[i];
                    if (cursel > best)
                    {
    
                        best = cursel;
    
                    }
                    Console.WriteLine(cursel);
                    Console.WriteLine(best);
                }
    
    	}
    }

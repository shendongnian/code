    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		try
    		{
    			Task.WhenAll(GetLazilyGeneratedSequenceOfTasks()).Wait();	
    			Console.WriteLine("Fisnished.");
    		}
    		catch (Exception ex)
    		{
    			Console.WriteLine(ex);	
    		}	
    	}
    	
    	public static IEnumerable<Task> GetLazilyGeneratedSequenceOfTasks()
    	{
    		var random =  new Random();
    		var finished = false;
    		while (!finished)
    		{
    			var n = random.Next(1, 2001);
    			if (n < 50)
    			{
    				finished = true;
    			}
    			
    			if (n > 499)
    			{
    				yield return Task.Delay(n);
    			}
    			
    			Task.Delay(20).Wait();				
    		}
    		
    		yield break;
    	}
    }

    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    public class Program
    {
    	private static BlockingCollection<Task<int>> BlockingCollection {get;set;}	
    	
    	public static void Producer(int numTasks)
    	{
    		Random r = new Random(7);
    		for(int i = 0 ; i < numTasks ; i++)
    		{
    			int closured = i;
    			Task<int> task = new Task<int>(()=>
    			{ 
    				Thread.Sleep(r.Next(100));
    				Console.WriteLine("Produced: " + closured);
    				return closured;
    			});
    			BlockingCollection.Add(task);
    			task.Start();
    		}
    		BlockingCollection.CompleteAdding();
    	}
    
    	
    	public static void Main()
    	{
    		int numTasks = 20;
    		int maxParallelism = 3;
    
    		BlockingCollection = new BlockingCollection<Task<int>>(maxParallelism);
    		
    		Task.Factory.StartNew(()=> Producer(numTasks));
    		
    		foreach(var task in BlockingCollection.GetConsumingEnumerable())
    		{
    			task.Wait();
    			Console.WriteLine("              Consumed: "+ task.Result);
    			task.Dispose();
    		}
    		
    	}
    }

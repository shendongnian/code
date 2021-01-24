    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class Program
    {
    	
    	public class TaskResult<T>
    	{
    		public T Result { get; set; }
    	}
    	
    	public static void Main()
    	{
    		BlockingCollection<int> bc = new BlockingCollection<int>();
    		
    		int numTasks = 10;
    		TaskResult<int>[] taskResults = new TaskResult<int>[numTasks];
    		int currentTask = 0;
    		Task.Factory.StartNew(() =>
    							  {
    								  Parallel.For(0, numTasks, i =>
    											   {
    												   Thread.Sleep(100); // do work
    												   
    												   taskResults[i] = new TaskResult<int>()
    												   {
    													   Result = i,
    												   };
    												   
    												   lock(taskResults)
    												   {
    													   for(int j = currentTask;j<taskResults.Length;j++)
    													   {
    														   var taskResult = taskResults[j];
    														   if(taskResults[j] != null)
    														   {
    															   bc.Add(taskResult.Result);
    															   currentTask++;
    														   }
    														   else
    														   {
    															   break;
    														   }
    													   }
    												   }
    											   });
    								  bc.CompleteAdding();
    							  });
    		
    		
    		foreach(var item in bc.GetConsumingEnumerable())
    		{
    			Console.WriteLine(item);
    		}
    	}
    }

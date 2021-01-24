    using System;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using Nito.AsyncEx;
    					
    public class Program
    {
    	public static async Task RateLimit(IEnumerable<Func<Task>> tasks, double rateLimit){
    	    var s = System.Diagnostics.Stopwatch.StartNew();
    		var n = 0;
    	    var batch = new List<Task>();
    		var sem = new  AsyncCountdownEvent(1);
    
    		foreach (var taskFn in tasks){
    			Console.WriteLine("Starting " + n++);
    	 
    			var time = s.Elapsed.TotalSeconds;
    			var timeout = n / rateLimit;
    			var delay = timeout - time;
    			if(delay > 0){
    				Console.WriteLine("Pausing for " + delay + "seconds");
    				await Task.Delay(TimeSpan.FromSeconds(delay));
    			}
    		
    			sem.AddCount(1);		
    		    Task.Run(async ()=>{
         			await taskFn();
    				sem.Signal();
    			});
    				
    			
    
    		}
    		sem.Signal();
    		await sem.WaitAsync();
    		Console.WriteLine("Current count is " + sem.CurrentCount);
    	}

    public class AsynchronousWrapper
    {
    	private Task previousTask = Task.CompletedTask;    	
        private SynchronousProcessor proc = new SynchronousProcessor();
    
        public Task<string> ProcessAsync(string arg)
        {
    		lock (proc)
    		{
    			var task = previousTask.ContinueWith(_ => proc.Process(arg));
    		
    			previousTask = task;
         		return task;
    		}	  		
        } 
    }

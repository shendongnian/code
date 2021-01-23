    public class ParallelProcessor
    {
        private Action[] actions;
    	private SemaphoreSlim concurrencySemaphore;
    
        public ParallelProcessor(Action[] actionList, int maxConcurrency)
        {
            this.actions = actionList;
            concurrencySemaphore = new SemaphoreSlim(maxConcurrency);
        }
    
        public void RunAllActions()
        {
            if (Utility.IsNullOrEmpty<Action>(actions))
                throw new Exception("No Action Found!");
    
    		foreach (Action action in actions)
    		{
    			Task.Factory.StartNew(() =>
    				{
    					concurrencySemaphore.Wait();
    					try
    					{
    						action();
    					}
    					finally
    					{
    						concurrencySemaphore.Release();
    					}
    				});
    		}
        }
    }

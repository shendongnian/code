    void Main()
    {
    	// Modified Async Scheduler for Continuations to work on Exactly same thread
    	// Required in the case same Thread is required for Task Continuation post await
    	Run(async () => await DemoAsync());
    
    	"Main Complete".Dump();
    }
    
    static async Task DemoAsync()
    {
    	// Transcation Scope test (shall dispose 
    	using (var ts = new TransactionScope())
    	{            
    		await Cache + Database Async update
    		ts.Complete();
    		"Transaction Scope Complete".Dump();
    	}	
    }
    
    // Run Method to utilize the Single Thread Synchronization context, thus ensuring we can
    // Control the threads / Synchronization context post await, cotinuation run of specific set of threads
    
    public static void Run(Func<Task> func)
    {
    	// Fetch Current Synchronization context
    	var prevCtx = SynchronizationContext.Current;
    
    	try
    	{
    		// Create SingleThreadSynchronizationContext
    		var syncCtx = new SingleThreadSynchronizationContext();
    
    		// Set SingleThreadSynchronizationContext
    		SynchronizationContext.SetSynchronizationContext(syncCtx);
    
    		// Execute Func<Task> to fetch the task to be executed
    		var t = func();
    
    		// On Continuation complete the SingleThreadSynchronizationContext
    		t.ContinueWith(
    			delegate { syncCtx.Complete(); }, TaskScheduler.Default);
    
    		// Ensure that SingleThreadSynchronizationContext run on a single thread
    		// Execute a Task and its continuation on same thread
    		syncCtx.RunOnCurrentThread();
    
    		// Fetch Result if any
    		t.GetAwaiter().GetResult();
    	}
    	// Reset the Previous Synchronization Context
    	finally { SynchronizationContext.SetSynchronizationContext(prevCtx); }
    }
    
    // Overriden Synchronization context, using Blocking Collection Consumer / Producer model
    // Ensure that same Synchronization context / Thread / set of threads are maintained
    // In this case we main a single thread for continuation post await
    
    private sealed class SingleThreadSynchronizationContext : SynchronizationContext
    {
    	// BlockingCollection Consumer Producer Model
    	private readonly BlockingCollection<KeyValuePair<SendOrPostCallback, object>>
    	  m_queue = new BlockingCollection<KeyValuePair<SendOrPostCallback, object>>();
    
    	// Override Post, which is called during Async continuation
    	// Send is for Synchronous continuation
    	public override void Post(SendOrPostCallback d, object state)
    	{
    		m_queue.Add(
    			new KeyValuePair<SendOrPostCallback, object>(d, state));
    	}
    
    	// RunOnCurrentThread, does the job if fetching object from BlockingCollection and execute it
    	public void RunOnCurrentThread()
    	{
    		KeyValuePair<SendOrPostCallback, object> workItem;
    		while (m_queue.TryTake(out workItem, Timeout.Infinite))
    			workItem.Key(workItem.Value);
    	}
    
    	// Compete the SynchronizationContext
    	public void Complete() { m_queue.CompleteAdding(); }
    }

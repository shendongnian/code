    private object _OnProcessItemLockObject = new object();
    // This method is executed by multiple threads at the same time
    protected override void OnProcessItem()
    {
        MyObject myObject = new MyObject();
    
        // Begin of the code that should be executed only once at a time
        // by each thread
    
    	bool result = false;
    	lock(_OnProcessItemLockObject)
    	{
    		//mat: the part inside the lock will only be executed by one thread. All other threads will wait till the lock-object is unlocked.
    		result = myObject.DoComplexStuff();
    	}
    	
    	//mat: the following code will get executed parallel
        if(result == true)
        {
            this.Logger.LogEvent("Write something to log");
            // ... Do more stuff
        }
        else
        {
            this.Logger.LogEvent("Write something else to log");
            // ... Do more stuff
        }
    
        // ... Do more stuff
    
        // End of the code that should be executed only once at a time
        // by each thread
    }

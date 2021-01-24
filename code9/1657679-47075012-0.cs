    public static void SomeThreadAction(object id)
    {
    	var ev = new ManualResetEvent(false);
    	events[id] = ev; // store the event somewhere
    
    	Thread.Sleep(2000 * (int)id); // do your work
    
    	ev.Set(); // set the event signaled
    }

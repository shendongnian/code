    class EventEmitter
    {
    	public event Func<bool> FooEvent;
    	public EventEmitter()
    	{
    		//....
    	}
    	
    	private void Emit()
    	{
    		var handlers = FooEvent.GetInvocationList();
    		foreach (Func<bool> handler in handlers)
    		{
    			var result = handler();
    			if (!result)
    			{
    				break;
    			}
    		}
    	}
    }

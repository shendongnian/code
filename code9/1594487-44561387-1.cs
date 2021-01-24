    public static event EventHandler MyEvent;
    
    private void OnMyEvent()
    {
    	if (MyEvent != null)
    	{
    		MyEvent(this, new EventArgs());
    	}
    }

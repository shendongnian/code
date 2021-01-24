    DateTime _lastEventTime = DateTime.MinValue;
    
    private void UserControl_MouseMove(object sender, MouseEventArgs e)
    {
    	if (IsMouseCaptured && snappedVertically) //The IsMouseCaptured listens for mouse movement and snapped vertically is what I am using to snap the GUI element
    	{
    		if (snappedVertically)
    		{
    			if ((DateTime.Now - _lastEventTime) < TimeSpan.FromSeconds(2))
    			{
    				snappedVertically = false;
    			}
    		}
    	}
    	
    	_lastEventTime = DateTime.Now;
    }

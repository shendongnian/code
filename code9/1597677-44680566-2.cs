    private async void UserControl_MouseMove(object sender, MouseEventArgs e)
    {
    	if (IsMouseCaptured && snappedVertically) //The IsMouseCaptured listens for mouse movement and snapped vertically is what I am using to snap the GUI element
    	{
    		if (snappedVertically)
    		{
    			await Task.Delay(2000);
    			snappedVertically = false;
    		}
    	}
    }

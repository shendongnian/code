    public class TimePickerDismissal
    {
    	private bool _active;
    	private bool _timeChanged;
    
    	public event EventHandler Dismissed;
    
    	public TimePickerDismissal(TimePicker timer)
    	{
    		timer.GotFocus += OnTimeGotFocus;
    		timer.LostFocus += OnTimeLostFocus;
    		timer.TimeChanged += OnTimeChanged;
    	}
    
    	private void OnTimeGotFocus(object sender, RoutedEventArgs e)
    	{
    		if (!_active)
    		{
    			return;
    		}
    
    		_active = false;
    
    		if (!_timeChanged)
    		{
    			Dismissed?.Invoke(this, EventArgs.Empty);
    		}
    
    		_timeChanged = false;
    	}
    
    	private void OnTimeLostFocus(object sender, RoutedEventArgs e)
    	{
    		var selector = FocusManager.GetFocusedElement() as LoopingSelector;
    
    		if (selector == null)
    		{
    			return;
    		}
    
    		_active = true;
    	}
    
    	private void OnTimeChanged(object sender, TimePickerValueChangedEventArgs e)
    	{
    		_timeChanged = true;
    	}
    }

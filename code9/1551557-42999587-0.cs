    public IEnumerable<Control> GetControlsOfType<T>(Control parent)
    {
    	if (parent.HasControls())
    	{
    		foreach (Control childControl in parent.Controls)
    		{
    			if (childControl is T)
    				yield return childControl;
    
    			foreach (var nextLevel in GetControlsOfType<T>(childControl))
    			{
    				yield return nextLevel;
    			}
    		}
    	}
    }

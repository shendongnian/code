	private bool MyFilter(object item)
	{
    	if (String.IsNullOrEmpty(this.TextToFilter))
    	{
        	return true;
    	}
    	else
    	{
        	DataModel m = (item as DataModel);
        	bool result = (m.DepartmentDisplay.IndexOf(this.TextToFilter, StringComparison.OrdinalIgnoreCase) >= 0);
	
        	return result;
    	}
	}

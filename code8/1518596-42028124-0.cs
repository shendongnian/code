    if (SearchBar != null)
    {
    	bool valuePatternExist = (bool)SearchBar.GetCurrentPropertyValue(AutomationElement.IsValuePatternAvailableProperty);
    	if (valuePatternExist)
    	{
    		ValuePattern val = SearchBar.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
    		if (val.Current.Value.Contains("youtube.com") || val.Current.Value.Contains("youtube.co.uk"))
    			proc.Close();
    	}
    }

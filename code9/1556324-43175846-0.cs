	//example 1
	public bool IsAt()
	{
		return this.IsAt(ObjectRepository.H1, ObjectRepository.PageHeaderLocator.Text, $"Login Page loaded successfully");
	}
	
	//example 2
	public bool IsAt()
	{
		return this.IsAt(ObjectRepository.UseAuthCodeBy, ObjectRepository.UseAuthCodeLocator.Text, "Select two factor provider page loaded successfully!");
	}
	
	//example 3
	public bool IsAt()
	{
		return this.IsAt(ObjectRepository.H1, ObjectRepository.PageHeaderLocator.Text, "Forgot password page loaded successfully");
	}
	
	//base class
	protected bool IsAt(object element, string match, string message)
	{
	    try
	    {
	        DriverUtils.WaitTillElementVisible(_driver, element);
	    }
	    catch (WebDriverTimeoutException)
	    {
	        return false;
	    }
	
	    if(match != ObjectRepository.TextInPageIdentifier)
	        return false;
	    Console.WriteLine(message);
	    return true;
	}

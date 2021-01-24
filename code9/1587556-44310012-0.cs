	IWebElement userNameField = null;
	try 
	{
		userNameField = driver.FindElementById("id_email");
	}
	catch(NoSuchElementException e)
	{
		// If you are creating a unit test
		Assert.Fail("Element "userNameField" not found.")
	}
    
    // If you just want the if:
	if(userNameField != null)
	{
		userNameField.SendKeys("xxxxx");
	}
	else 
	{
		// do your thing
	}
	

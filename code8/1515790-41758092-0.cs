     foreach (IWebElement element in menuElements )
     {
    	string value= element.FindElement(By.TagName("div")).Text;
    	if(value.Equals("Faster"))
    	{	
                element.click();
    	}
     }

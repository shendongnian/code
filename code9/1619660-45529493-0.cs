    public void CallingFunction(){
    IWebElement el1= driver.FindElement(.....)// find control
    SetValue(el1, value);
    el1= driver.FindElement(.....)// find control again
    CheckValue(el1, value)
    }
    
    public void SetValue(IWebelement element, string value)
    {
       element.SendKeys(value);
    }
    
    public void SetValue(IWebelement element, string value)
    {
       if(element.Text!=value)
          throw new Exception("Failed to set value.");
    } 
 

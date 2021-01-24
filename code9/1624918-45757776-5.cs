    public void Get()
    {
        //Your code
        string returnValue;
        try
        {
            returnValue = GetInformation();
        }
        catch (Exception)
        {
            return;
        }
        //Code that will not cause exception
        try
        {
            //Another possible line of causing exception
        }
        catch (Exception)
        {
            return;
        }
        //Code that will not cause exception
    }
    public string GetInformation()
    {
        try
        {
            //Your Code
        }
        catch (Exception e)
        {
            //Error message
            throw new Exception();
        }
    }

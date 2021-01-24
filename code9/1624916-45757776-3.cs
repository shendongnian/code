    public void Get()
    {
        try
        {
            var returnValue = GetInformation();
        }
        catch (Exception)
        {
            return;
        }
    }
    public string GetInformation()
    {
        try
        {
            var returnValue = GetInformation();
        }
        catch (Exception e)
        {
            //Error message
            throw new Exception();
        }
    }

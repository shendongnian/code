    public void TestMethod()
    {
        try
        {
            // can throw an exception specific to the project or a .Net exception 
            SomeWorkMethod() 
        }
        catch(Exception ex) when (!(ex is SpecificException))
        {
            throw new SpecificException(ex);
        }
    }

    void OuterMethod()
    {
        try
        {
            InnerMethod();
        }
        catch(Exception ex)
        {
            //Exception Handled.
        }
    }
    
    void InnerMethod()
    {
        try
        {
            //Some Exception Thrown.
        }
        catch(Exception ex)
        {
            //Exception Handled.
            //some logic
            throw;
        }
    }

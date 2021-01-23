    void OuterMethod()
    {
        try
        {
            InnerMethod();
        }
        catch(Exception ex)
        {
            //Handle Exception
        }
    }
    void InnerMethod()
    {
        //if exception occurs, throw
    }

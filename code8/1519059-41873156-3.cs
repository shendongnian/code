    try
    {
        // Call your WCF service here...
    }
    catch (FaultException<MyResultClass> e)
    {
        MyResultClass detail = e.Detail;
        // Do stuff with detail
    }
    catch (Exception e)
    {
        // Some other error
    }

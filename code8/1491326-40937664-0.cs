    public void Test(Action success, Action<Exception> error)
    {
        try
        {
            // perform some task
            success();
        }
        catch (Exception ex)
        {
            error(ex);
        }
    }

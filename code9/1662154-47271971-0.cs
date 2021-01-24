    public static void RunVoidMethod<T>(Action<T> methodToRun, T param)
    {            
        try
        {
            methodToRun(param);
        }
        catch (Exception e)
        {
            throw;
        }    
    }

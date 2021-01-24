    bool Retry(int numberOfRetries, Action method)
    {
        if (numberOfRetries > 0)
        {
            try
            {
                method();
                return true;
            }
            catch (Exception e)
            {
                // Log the exception
                LogException(e); 
                // wait half a second before re-attempting. 
                // should be configurable, it's hard coded just for the example.
                Thread.Sleep(500); 
                
                // retry
                return Retry(--numberOfRetries, method);
            }
        }
        return false;
    }

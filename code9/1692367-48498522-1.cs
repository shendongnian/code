    driver driver = null;
    
    try
    {
        try
        {
            driver = new driver();
        }
        catch(Exception ex)
        {
            // Here is your specific exception.
        }
     
        // Do something
    }
    finally
    {
        if(driver != null)
            driver.Dispose();
    }

    int retryCount = 0;
      
    while (retryCount < 10)
                {
                    try
                    {
                        // Execute SQL Stored Procedure    
                    }
                    catch (Exception ex)
                    {
                        retryCount++;    
                    }
                }

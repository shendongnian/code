    // Method with try...catch
    public void MethodName()
    {
        try
        {
            if (...)
            {
                // other stuff
            }
            else
            {
                conn.Open(); // --> opening DB connection
        
                // other stuff
        
                conn.Close(); // --> closing DB connection
            }
        }
        catch (Exception ex)
        {
            // exception handling
        }
    }
    // Other method
    public void OtherMethodName()
    {
        // opening connection - will trigger exception if conn.Close in MethodName not executed!
        conn.Open(); 
    
        // other stuff
    
        conn.Close();
    }

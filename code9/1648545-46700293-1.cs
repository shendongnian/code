    try
    {
        if (...)
        {
            // other stuff
        }
        else
        {
            conn.Open();
    
            // other stuff
        }
    }
    catch (Exception ex)
    {
        // exception handling
    }
    finally
    {
        // always executed regardless of exception
        if (conn.State == ConnectionState.Open)
            conn.Close();
    }

    SqlConnection connection = new SqlConnection("");
    try {
    
    }
    catch (Exception exc) {
        Log(exc);
    }
    finally {
        connection.Dispose();
    }

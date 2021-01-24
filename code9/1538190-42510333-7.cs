    SqlConnection connection = new SqlConnection("");
    try {
    
    }
    catch (SqlException exc) when (exc.Number > 0) {
        //Handle SQL error
    }
    catch (Exception exc) {
        Log(exc);
    }
    finally {
        connection.Dispose();
    }

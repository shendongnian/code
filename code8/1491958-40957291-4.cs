    try
    {
        Sqlconnection conn = new SqlConnection("your conn string");
    }
    catch(Exception ex)
    {
        throw;
    }
    finally
    {
        conn.Close();
    }

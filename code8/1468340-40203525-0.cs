    try
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
        }
    }
    catch (SqlException ex)
    {
        //do some action
    }
    catch (InvalidOperationException ex)
    {
        //do some action
    }

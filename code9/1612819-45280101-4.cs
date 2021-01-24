    public static async Task<bool> ConnectDataBase()
    {
        var connection = new SqlConnection("connection string");
        try
        {
            await connection.OpenAsync();
            // store "connection" somewhere I assume?
            return true;
        }
        catch (SqlException)
        {
            connection.Dispose();
            return false;
        }
    }

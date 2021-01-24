    public static Tuple<bool, Exception> TestConnection(this IDbConnection connection)
    {
        try
        {
            connection.Open();
            connection.Close();
            return new Tuple<bool, Exception>(true, null);
        }
        catch(Exception e)
        {
            return new Tuple<bool, Exception>(false, e);
        }
    }

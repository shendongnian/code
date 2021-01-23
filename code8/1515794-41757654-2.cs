    public static DataSet SelectDataSet(string sql, bool isProcedure, out string message, Dictionary<string, object> parameters = null)
    {
        // Rest of codes here
    
        try
        {
            message = "Success";
            adapter.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return null;
        }
    
    }

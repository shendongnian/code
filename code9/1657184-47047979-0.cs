    try
    {
        //code
    }
    catch(SqlException sqlEx)
    {
            if (sqlEx.Message.StartsWith("Invalid object name"))
            {
                //code
            }
            else
                throw;
    }

    try
    {
        dbConnection.Open();
        using (SqlDataReader dr = dbCommand.ExecuteReader())
        {
            if (dr.Read())
            {
                Value = dr[Field].ToString();
            }
            else
            {
                Value = "";
            }
        }
    }
    catch(Exception ex)
    {
        //Do some treatment
    }
    finally
    {
        //If connection has been opened, close it.
        if(dbConnection.ConnectionState == ConnectionState.Open)
        {
            dbConnection.Close();  
        } 
    }

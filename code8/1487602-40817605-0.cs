    int newID = 0;
    
    using (SqlConnection connection = new SqlConnection(strConnString))
    using (SqlCommand command = new SqlCommand(strQuery, connection))
    {
        command.CommandType = CommandType.Text;
        command.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName;
        command.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = "/images/admin/news/" + FileName;
    
        try
        {
            connection.Open();
            newID = (int)command.ExecuteScalar();
        }
        catch 
        {
        }
    }
    
    if (newID > 0)
    {
        using (SqlConnection connection = new SqlConnection(strConnString))
        using (SqlCommand command = new SqlCommand(strAddNewsQuery, connection))
        {
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@newsTitle", SqlDbType.VarChar).Value = FileName;
            //etc
            command.Parameters.Add("@newsPicID", SqlDbType.Int).Value = newID;
    
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
            }
        }
    }

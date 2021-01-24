    public int GetLatestAccountID() 
    {
        try
        {
            int accounts = 0;
           
            command.CommandText = "select Max(AccountID)as maxID from Account";
            command.CommandType = CommandType.Text;
            connection.Open();
            OleDbDataReader reader= command.ExecuteReader();
            if (reader.Read())
            {
                accounts = Convert.ToInt32(reader["maxID"]) + 1;
            }
            return accounts;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (connection!= null)
            {
                connection.Close();
            }
        }
    }

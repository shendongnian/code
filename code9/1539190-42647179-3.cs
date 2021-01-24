    public List<MessageClass> ChequesToUpdate()
    {
        message = new List<MessageClass>();
        MessageClass item = new MessageClass();
        try
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
                {
                    item.message = e.Message;
                };
                using (SqlCommand command = new SqlCommand("MyStoredProcedure", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception e)
        {
            item.message = e.Message;
        }
        finally
        {
            connection.Close();
        }
        message.Add(item);
        return message;
    }

    try
      {
        nErrorMsg = nErrorMsg.Truncate(2000);
        using (SqlConnection sqlErrorLogConn = new SqlConnection(SqlConnString.ErrorLogConn))
        {
          try
          {
            sqlErrorLogConn.Open();
          }
          catch (Exception)
          {
            MessageBox.Show("There was an error whilst opening the connection with the database - (WriteToErrorLog)", "Connection Error", 0, MessageBoxIcon.Error);
            return;
          }
          using (SqlCommand sqlErrorLogCommand = sqlErrorLogConn.CreateCommand())
          {
            string sqlCommandText = string.Format("INSERT INTO [dbo].[Error_Log] (Description,LoggedAt,ComputerName) VALUES (@Description,@LoggedAt,@ComputerName);");
            sqlErrorLogCommand.CommandText = sqlCommandText;
            sqlErrorLogCommand.Prepare();
            sqlErrorLogCommand.Parameters.AddWithValue("@Description", nErrorMsg);
            sqlErrorLogCommand.Parameters.AddWithValue("@LoggedAt", DateTime.Now);
            sqlErrorLogCommand.Parameters.AddWithValue("@ComputerName", Environment.MachineName);
            sqlErrorLogCommand.ExecuteNonQuery();
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("There was an error whilst communicating with the database: " + ex.ToString(), "Connection Error", 0, MessageBoxIcon.Error);
      }

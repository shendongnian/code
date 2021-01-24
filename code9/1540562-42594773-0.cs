    public static void DeleteTable(string TableName)
    {
      OleDbConnection connection = new OleDbConnection(OLEDB.ConStr);
      OleDbCommand oleDbCommand = new OleDbCommand(string.Format("delete from [{0}]", (object) TableName), connection);
      try
      {
        connection.Open();
        oleDbCommand.ExecuteNonQuery();
      }
      catch
      {
      }
      finally
      {
        connection.Close();
      }
    }

    public static bool CreateDBF()
    {
      try
      {
        string dbfDirectory = @"c:\Users\er4505\Desktop\New911";
        string connectionString = "Provider=VFPOLEDB;Data Source=" + dbfDirectory;
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
          connection.Open();
          OleDbCommand command = connection.CreateCommand();
          command.CommandText = "create table CustomProperties(Public C(60))";
          command.ExecuteNonQuery();
          connection.Close();
        }
        InsertDataIntoDBF(dbfDirectory + "\\CustomProperties.DBF");
        return true;
      }
      catch (Exception ex)
      {
        string viewError = JsonConvert.SerializeObject(ex);
        return false;
      }
    }
    public static bool InsertDataIntoDBF(string path)
    {
      try
      {
        string strLogConnectionString = "Provider=VFPOLEDB;Data Source=" + path + ";Collating Sequence=machine;Mode=ReadWrite;";
        string query = "INSERT INTO CustomProperties(Public) VALUES (?)";
        using (OleDbConnection connection = new OleDbConnection(strLogConnectionString))
        {
          connection.Open();
          OleDbCommand cmdInit = new OleDbCommand("set null off", connection);
          cmdInit.ExecuteNonQuery();
          OleDbCommand command = new OleDbCommand(query, connection);
          OleDbParameter publicStatus = command.Parameters.Add("Public", OleDbType.Char);
          publicStatus.Value = "True";
          command.ExecuteNonQuery();
          connection.Close();
        }
        return true;
      }
      catch (Exception ex)
      {
         log4net.LogManager.GetLogger("EmailLogger").Error(JsonConvert.SerializeObject(ex));
                string viewError = JsonConvert.SerializeObject(ex);
                return false;
            }
        }

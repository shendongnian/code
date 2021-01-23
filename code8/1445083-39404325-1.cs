    class SQLQuery
    {
        public static DataSet SQLGetData(string ConnectionString, string commandString)
        {            
            DataSet DS = new DataSet();
            DataTable DT = new DataTable("Table1");
            DS.Tables.Add(DT);
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {               
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(commandString, connection);
                    //command.CommandTimeout = 3000;
                    SqlDataReader read = command.ExecuteReader();
                    
                    DS.Load(read, LoadOption.PreserveChanges, DS.Tables[0]);  
                }
                catch (SqlException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }               
            }
            return DS;
        }
    }

    public DataTable fillDataTable(string sqlCommand)
    {
         DataTable dt = new DataTable();
         String config = "your connection string";
         using (var con = new SQLiteConnection { ConnectionString = config })
         {
              using (var command = new SQLiteCommand { Connection = con })
              {
                   if (con.State == ConnectionState.Open)
                       con.Close();
    
                   con.Open();
                   command.CommandText = sqlCommand;
    
                   dt.Load(command.ExecuteReader());
    
               }
               return dt;
         }
    }
 

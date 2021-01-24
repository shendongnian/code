    DataSet excelDataSet = new DataSet();
    using (OleDbConnection connection = new System.Data.OleDb.OleDbConnection(connectionString))
    {
         connection.Open();
         OleDbDataAdapter cmd = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$1:10000]", connection);
         cmd.Fill(excelDataSet);
         connection.Close();
    }

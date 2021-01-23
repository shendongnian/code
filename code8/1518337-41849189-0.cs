     public void FunctionName()
        {
            DataSet ds = new DataSet();
            System.Data.OleDb.OleDbConnection conn = new
               System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Your Path DataBase";
            conn.Open();
            string sql = "SELECT * FROM YourTable where Id ='" + YourID + "' ;";
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, conn);
            dataadapter.Fill(ds, "YourTable");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "YourTable";
        }

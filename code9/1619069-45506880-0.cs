            OleDbConnectionStringBuilder connStringBuilder = new OleDbConnectionStringBuilder();
            connStringBuilder.DataSource =tmpFilePath;  // Set path to excel file
            connStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            connStringBuilder.Add("Extended Properties", "Excel 12.0;HDR=NO");
            
            string connectionString = connStringBuilder.ConnectionString;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                
                DataTable objSheetNames = conn.GetSchema("Tables");
                cmd.CommandText = string.Format(@"INSERT INTO [{0}](F1,F2,F3) VALUES('{1}','{2}','{3}');",
                            objSheetNames.Rows[0][2], "", "", "");
                cmd.ExecuteNonQuery();
           }  

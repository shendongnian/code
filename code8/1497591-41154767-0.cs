        using (OleDbConnection cuConn = new OleDbConnection())
        {
            cuConn.ConnectionString = @"DATASOURCE";
            string statement = "SELECT COUNT(*) FROM [Users]";
            OleDbCommand cmd = new OleDbCommand (statement, cuConn);
            cuConn.Open();
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
            {
                //
            }
            cuConn.Close();
        }

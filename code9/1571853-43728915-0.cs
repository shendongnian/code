    OleDbConnection connection;
    OleDbCommand command;
    OleDbDataReader dr;
            string commandText = "SELECT * FROM [Sheet1$]";
            string oledbConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=" + filename + ";" +
            "Extended Properties=\"Excel 12.0;HDR=YES\";";
            connection = new OleDbConnection(oledbConnectString);
            command = new OleDbCommand(commandText, connection);
            try
            {
                connection.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    count++;
                    for (int i = 1; i < dr.VisibleFieldCount; i++)
                    {
                       Console.Writeln(""+dr[i].ToString());
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                connection.Close();
            }

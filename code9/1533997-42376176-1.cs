    private void Insert(string value)
        {
            //Your code here to save on database
            OleDbConnection connection = new OleDbCommand("Your sql connection String");
            OleDbCommand command = new OleDbCommand("Your sql insert query");
            command.Connection = connection;
            //Parámeters of command
            OleDbParameter param = new OleDbParameter("Parameter name and next your type", OleDbType.VarChar);
            param.Value = value;
            
            command.Parameters.Add(param);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            
            //Your value is saved now
        }

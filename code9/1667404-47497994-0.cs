    public DataTable FillDataTable()
    {
        DataTable table = new DataTable();
        try
        {    
            // Define the connection credentials
            string ConnectionString = "server=SERVER;port=PORT;database=DATABSAE;uid=USERNAME;pwd=PASSWORd;"; 
            string commandString = "Select * from table1;";
            //Use the connection
            using(MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                _Conn.Open();
                //Pass in command text and connection string
                using(MySqlCommand command = new MySqlCommand(ConnectionString)
                {
                    command.Connection = connection;
                    command.Text = commandString;
                    //Any parameters in command string, add here
                    //command.Parameters.AddWithValue("@SomeValue", value)
                    using(MySqlDataReader reader = command.ExecuteReader)
                    {
                        table.Load(reader);
                    }
                }
            }           
        }
        catch(Exception ex)
        {
            //Catch any exceptions here
        }
        return table;
    }

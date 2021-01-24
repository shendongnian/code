    public bool IsConnect()
    {
        bool result = false;
        if (connection == null)
        {
            //Checking if all required parameters for connection are having values.
            if (!string.IsNullOrEmpty(databaseName) && !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                //Creating new connection.
                string connstring = string.Format("Server=.;database={0};UID={1};password={2}", databaseName, Username, Password);
                connection = new SqlConnection(connstring);
            }
        }
        //Check if connection is not null.
        if (connection != null)
        {
            //Check if current status of the connection is open. 
            //If Yes set result = true
            if (connection.State == ConnectionState.Open)
            {
                result = true;
            }
            else
            {
                // If connection not already opened, open it.
                connection.Open();
                result = true;
            }
        }
        return result;
    }

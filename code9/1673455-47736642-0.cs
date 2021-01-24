    using(var con = new SqlConnection(connectionString))
    {
        using(var cmd = new SqlCommand(commandText, con)
        {
            // Add parameters if needed: 
            // cmd.Parameters.Add("name", SqlDbType.<some SqlDbType Member>).Value = <some value>
            // Execute your command here and do whatever you need with it.
        }
    }

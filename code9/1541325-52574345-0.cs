    public void PopulateDropdown()    
        {   
            // Check to see if connection is closed, to be safe, if closed then open
            if (connection_db.State == ConnectionState.Closed)
                connection_db.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("StoredProcedureHere", connection_db);
            // Must specify 'SelectCommand' when using get queries
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable table = new DataTable();
            // Store data in table
            sqlData.Fill(table);
            dropdownForNames.ValueMember = "player_id";
            dropdownForNames.DisplayMember = "name";
            dropdownForNames.DataSource = table;
            
            // Close connection
            connection_db.Close();
        }

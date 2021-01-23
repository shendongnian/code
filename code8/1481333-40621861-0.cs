    private void BindData(string selectCommand)
    {
        try
        {
            string selectCommand = "SELECT * FROM tblCustomers";
            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;;
    
            // Create a new data adapter based on the specified query.
            var dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
    
            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. These are used to
            // update the database.
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
    
            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
          dataGridView1.DataSource = table;
        }
        catch (SqlException)
        {
            MessageBox.Show("To run this example, replace the value of the " +
                "connectionString variable with a connection string that is " +
                "valid for your system.");
        }
    }

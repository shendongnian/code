    var table = new DataTable(); // Create table for storing query results
    
    var connection = new SqlConnection("connectionString"); // Declare connection to server
    connection.Open(); // Attempt to connect to specified server
    
    var command = new SqlCommand("SELECT * FROM Table", connection); // Declare query for server
    var adapter = new SqlDataAdapter(command); // Declare a data adapter for the query
    adapter.Fill(table); // Execute the query
    
    var deleteCommand = new SqlCommand("DELETE FROM Table", connection); // Declare delete statement
    deleteCommand.ExecuteNonQuery(); // Execute delete statement
    
    var strBuilder = new StringBuilder(); // StringBuilder for creating SQL statements
    foreach (DataRow record in table.Rows) // For every row in the table
    {
        string[] physicians = record["PHYSICIAN_ID"].ToString().Split(','); // Turn the CSV format into a string[]
        foreach (string physician in physicians) // For all physicians for that patient
        {
            strBuilder.Append("INSERT INTO Table (PATIENT_ID, PHYSICIAN_ID) VALUES ("
                + record["PATIENT_ID"].ToString() + ", " + physician + ");");
            // Append the StringBuilder with a statement to insert the new record
            // for every physician as applicable
        }
    }
    
    var insertCommand = new SqlCommand(strBuilder.ToString(), connection); // Create insert statements from the StringBuilder
    insertCommand.ExecuteNonQuery(); // Execute insert statements
    
    connection.Close(); // Close connection to the server

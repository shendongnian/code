    // Location of the Database
    string connectionString;
    // Use a "Using" instead of a try-catch-finally statement for automatic Dispose
    using (var db = new SQLiteConnection (connectionString))
    {
       // Use a Data Adapter and CommandBuilder to initiate and receive the data from the db.
       SQLiteDataAdapter myDataAdapter = new SQLiteDataAdapter ("select * from Lists", connectionString);
       SQLiteCommandBuilder myCommand = new SQLiteCommandBuilder (myDataAdapter);
       
       // Create a Data Table to Store the db
       // Open the Database
       // Fill the Data Table from the Adapter that received the db
       DataTable newDataTable = new DataTable;
       db.Open();
       myDataAdapter.Fill (newDataTable);
       
       // Now if you run through each row and use "row.ItemArray[]" you can get 
       // the specific data type in each value.
       foreach (DataRow row in newDataTable.Rows)
       {
           "Your Rows Here"
       }
    }

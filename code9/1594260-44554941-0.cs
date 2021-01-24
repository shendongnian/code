    // Declare the function.  
    // As a good practice, use Pascal-casing for function/method names.
    // As a good practice, use camel-casing for parameter names.
    // Instead of passing in a SQL connection, pass a SQL connection string so that the connection 
    // can be opened and closed quickly.
    // This also takes advantage of connection pooling.
    public void InsertDataIntoProductTable(string prName, string prPrice, string prDescription, string category, string image1Url, string image2Url, string image3Url, string connectionString)
    {
        // Construct a parameterized SQL INSERT query.
        // Parameterized queries MUST be used to protect our systems from SQL injection attacks.
        // Use string construction so that the query is readable.
        string query = "INSERT Product_Table( " +
                               "prname" + 
                               ",prprice" + 
                               ",prdescription" + 
                               ",category" + 
                               ",image1url" + 
                               ",image2url" + 
                               ",image3url" +
                       ") values(" +
                               "@prname" + 
                               ",@prprice" + 
                               ",@prdescription" + 
                               ",@category" + 
                               ",@image1url" + 
                               ",@image2url" + 
                               ",@image3url" +
                       ")";
        // Create a SqlConnection object.
        // Use a using statement to insure that the SqlConnection object is closed and disposed off when finished.
        using(conn = new SqlConnection(connectionString))
        {
            // Create a SqlCommand object to execute the query.
            // Use a using statement to insure that the SqlCommand object is disposed when finished
            using(cmd = new SqlCommand(query, conn))
            {
                // Add parameters and their values to the SqlCommand object
                cmd.Parameters.AddWithValue(@prname, prName);
                cmd.Parameters.AddWithValue(@prprice, prPrice);
                cmd.Parameters.AddWithValue(@prdescription, prDescription);
                cmd.Parameters.AddWithValue(@catogory, category);
                cmd.Parameters.AddWithValue(@image1url, image1Url);
                cmd.Parameters.AddWithValue(@image2url, image2Url);
                cmd.Parameters.AddWithValue(@image3url, image3Url);
                // Open the database connection
                conn.Open();
                // Execute the SqlCommand.
                // Save the count of records inserted, if of interest to you.
                int recordAffectedCount = cmd.ExecuteNonQuery();
            }
        }
    }

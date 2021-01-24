    string conString = ConfigurationManager.ConnectionStrings
        ["SqlConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conString))
        {
        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
        {
        //Set the database table name.
        sqlBulkCopy.DestinationTableName = "dbo.Orders"; 

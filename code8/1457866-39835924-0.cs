    if (dt.Rows.Count > 0)
    {
        string consString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        using (SqlConnection con = new SqlConnection(consString))
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            {
                //Set target table
                sqlBulkCopy.DestinationTableName = "dbo.Customers";
 
                //Map the DataTable columns with the database table
                sqlBulkCopy.ColumnMappings.Add("Id", "CustomerId");
                sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                sqlBulkCopy.ColumnMappings.Add("Country", "Country");
                con.Open();
                sqlBulkCopy.WriteToServer(dt);
                con.Close();
            }
        }
    }

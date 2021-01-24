        using (SqlConnection con = new SqlConnection(_Conn.ConnStr()))
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            {
                //Set the database table name
                sqlBulkCopy.DestinationTableName = "dbo.tblPersons";
 
                //Might be a good idea to map excel columns with that of the database table (optional)
                sqlBulk.ColumnMappings.Add("Id", "PersonId");
                sqlBulk.ColumnMappings.Add("Name", "Name");
                con.Open(); // these might be the issue since you need to open..
                sqlBulk.WriteToServer(dtExcelData);
                con.Close(); // ..and close the connection
            }
        }

    var results = new DataTable();
    using(var myExcelConn = new OleDbConnection(excCnnStr))
    {
        using (var cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", myExcelConn))
        {
            myExcelConn.Open();
    
            var adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(results);
        }
    }
    
    //add new col
    results.Columns.Add("uploadedBy", typeof(System.Int32));
    foreach (var row in results.Rows)
    {
        row["uploadedBy"] = loggedInUserId; // set uploader
    }
    
    using (var con = new SqlConnection(sCon))
    {
        con.Open();
        using (var oSqlBulk = new SqlBulkCopy(con))
        {
            oSqlBulk.DestinationTableName = "Table3";
    
            oSqlBulk.ColumnMappings.Add("name", "name");
            oSqlBulk.ColumnMappings.Add("address", "address");
            oSqlBulk.ColumnMappings.Add("country", "country");
            oSqlBulk.ColumnMappings.Add("uploadedBy", "uploadedBy");
            oSqlBulk.WriteToServer(results);
        }
    } 

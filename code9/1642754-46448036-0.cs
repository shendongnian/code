    using(var bcp=OracleBulkCopy(connectionString))
    {
        bcp.BatchSize=5000;
        bcp.DestinationTableName = "MyTable";
       
        //For each source/target column pair, add a mapping
            bcp.ColumnMappings.Add("ColumnA","ColumnA");
        
        var reader = excelCommand.ExecuteReader();
        bcp.WriteToServer(reader);
    }
    
    

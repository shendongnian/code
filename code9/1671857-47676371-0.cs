    using (var oSqlBulk = new SqlBulkCopy(connectionString,SqlBulkCopyOptions.FireTriggers))
    {
        oSqlBulk.DestinationTableName = TableName; 
        oSqlBulk.WriteToServer(objBulkReader);
    }
                    
                   

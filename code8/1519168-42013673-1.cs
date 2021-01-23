    string excelConnectionString = @"Provider=Microsoft 
    .Jet.OLEDB.4.0;Data Source=Book1.xls;Extended 
    Properties=""Excel 8.0;HDR=YES;"""; 
    // Create Connection to Excel Workbook
    
    We can Import excel to sql server like this
    
    using (OleDbConnection connection = 
                 new OleDbConnection(excelConnectionString)){
    
    OleDbCommand command = new OleDbCommand 
                ("Select ID,Data FROM [Data$]", connection);
    
    connection.Open(); 
    
    
// Create DbDataReader to Data Worksheet 
    using (DbDataReader dr = command.ExecuteReader()) 
    { 
        // SQL Server Connection String 
        string sqlConnectionString = "Data Source=.; 
           Initial Catalog=Test;Integrated Security=True"; 
    
    
        // Bulk Copy to SQL Server 
        using (SqlBulkCopy bulkCopy = 
                   new SqlBulkCopy(sqlConnectionString)) 
        { 
            bulkCopy.DestinationTableName = "ExcelData"; 
            bulkCopy.WriteToServer(dr); 
        } 

    void Main()
    {
      string sqlConnectionString = @"server=.\SQLExpress;Trusted_Connection=yes;Database=Test";
    
      string path = @"C:\Users\Cetin\Documents\ExcelFill.xlsx"; // sample excel sheet
      string sheetName = "Sheet1$";
      
      using (OleDbConnection cn = new OleDbConnection(
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path+
        ";Extended Properties=\"Excel 8.0;HDR=Yes\""))
    
      using (SqlConnection scn = new SqlConnection( sqlConnectionString ))
      {
    
        scn.Open();
        // create temp SQL server table
        new SqlCommand(@"create table #ExcelData 
        (
          [Id] int, 
          [Barkod] varchar(20)
        )", scn).ExecuteNonQuery();
        
        // get data from Excel and write to server via SBC  
        OleDbCommand cmd = new OleDbCommand(String.Format("select * from [{0}]",sheetName), cn);
        SqlBulkCopy sbc = new SqlBulkCopy(scn);
        
        // Mapping sample using column ordinals
        sbc.ColumnMappings.Add(0,"[Id]");
        sbc.ColumnMappings.Add(1,"[Barkod]");
      
        cn.Open();
        OleDbDataReader rdr = cmd.ExecuteReader();
        // SqlBulkCopy properties
        sbc.DestinationTableName = "#ExcelData";
        // write to server via reader
        sbc.WriteToServer(rdr);
        if (!rdr.IsClosed) { rdr.Close(); }
        cn.Close();
        
        // Excel data is now in SQL server temp table
        // It might be used to do any internal insert/update 
        // i.e.: Select into myTable+DateTime.Now
        new SqlCommand(string.Format(@"select * into [{0}] 
                    from [#ExcelData]", 
                    "ImportFromExcel_" +DateTime.Now.ToString("yyyyMMddHHmmss")),scn)
            .ExecuteNonQuery();
        scn.Close();
      }
    }

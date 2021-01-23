    void Main()
    {
        var vfpConnection = @"Provider=VFPOLEDB;Data Source=D:\temp";
        var xlsFileName = @"D:\temp\ExcelImportData.xlsx";
        var xlsConnection = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={xlsFileName};" +
        "Extended Properties=\"Excel 12.0;HDR=Yes\"";
        var xlsTableName = "SampleSheet$";
        using (var xlsCon = new OleDbConnection(xlsConnection))
        using (var vfpCon = new OleDbConnection(vfpConnection))
        {
            var cmdInsert = new OleDbCommand(@"insert into SampleImport
            (CustomerId, OrderId, OrderDate, ShippedOn)
            values
            (?,?,?,?)", vfpCon);
            cmdInsert.Parameters.Add("customerId", OleDbType.WChar);
            cmdInsert.Parameters.Add("orderId", OleDbType.Integer);
            cmdInsert.Parameters.Add("orderDate", OleDbType.Date);
            cmdInsert.Parameters.Add("shippedOn", OleDbType.Date);
    
            var readXl = new OleDbCommand($"select * from [{xlsTableName}]", xlsCon);
            xlsCon.Open();
            vfpCon.Open();
            var xlReader = readXl.ExecuteReader();
            while (xlReader.Read())
            {
                cmdInsert.Parameters["customerId"].Value = xlReader["Customer ID"];
                cmdInsert.Parameters["orderId"   ].Value = xlReader["Order ID"];
                cmdInsert.Parameters["orderDate" ].Value = xlReader["Ordered On"];
                cmdInsert.Parameters["shippedOn" ].Value = xlReader["Shipped On"];
                cmdInsert.ExecuteNonQuery();
            }
            xlsCon.Close();
            vfpCon.Close();
        }
    }
  

    string xlConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=yourfullfilepathandname.xlsx;Extended Properties='Excel 8.0;HDR=Yes;';";
    var xlConn = new OleDbConnection(xlConnStr);
    
    var da = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", xlConn);
    var xlDT = new DataTable();
    da.Fill(xlDT);

        string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   "Data Source=e:\\Test.xlsx;" +
                                   "Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
        OleDbConnection oConnection = new OleDbConnection();
        oConnection.ConnectionString = sConnectionString;
        oConnection.Open();
        DataTable SheetContents = new DataTable();
        SheetContents.Load(new OleDbCommand("Select * From [Sheet1$]", oConnection).ExecuteReader());
        Console.WriteLine(SheetContents.Rows[0].ItemArray[0]);
        Console.WriteLine(SheetContents.Rows[0].ItemArray[1]);
        Console.WriteLine(SheetContents.Rows[0].ItemArray[2]);
        oConnection.Close();

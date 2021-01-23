        string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   "Data Source=e:\\Test.xlsx;" +
                                   "Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
        OleDbConnection oConnection = new OleDbConnection();
        oConnection.ConnectionString = sConnectionString;
        oConnection.Open();
        //Find all readable Named Ranges and Worksheets
        DataTable ExcelSheetNames = oConnection.GetSchema("Tables");
        foreach (DataRow SheetNameRow in ExcelSheetNames.Rows)
        {
            string SheetName = (string)SheetNameRow["Table_Name"];
            //Only handle WorkSheets. Named Ranges are otherwise named.
            if (SheetName.EndsWith("$") | SheetName.EndsWith("$'"))
            {
                DataTable SheetContents = new DataTable();
                //Read the contents of the sheet into a DataTable
                using (OleDbCommand oCmd = new OleDbCommand("Select * From [" + SheetName + "]", oConnection))
                {
                    SheetContents.Load(oCmd.ExecuteReader());
                }
                //You can also put the DataTable load on one line (I do)
                //SheetContents.Load(new OleDbCommand("Select * From [" + SheetName + "]", oConnection).ExecuteReader());
                //Print the content of cells A2..C2 to the console window
                Console.WriteLine(SheetContents.Rows[0].ItemArray[0]);
                Console.WriteLine(SheetContents.Rows[0].ItemArray[1]);
                Console.WriteLine(SheetContents.Rows[0].ItemArray[2]);
           }
        }
            
        oConnection.Close();

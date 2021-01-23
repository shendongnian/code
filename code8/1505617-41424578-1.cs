    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO\"");
    con.Open();
    DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    string getExcelSheetName = (string)dt.Rows[0]["Table_Name"];
    DataTable xlWorksheet = new DataTable();
    xlWorksheet.Load(new OleDbCommand("Select * From [" + getExcelSheetName + "]", con).ExecuteReader());
    //More than 11 rows implies 11 header rows and at least 1 data row
    if (xlWorksheet.Rows.Count > 11 & xlWorksheet.Columns.Count >= 10)
    {
        for (int nRow = 11; nRow < xlWorksheet.Rows.Count; nRow++)
        {
            DataRow returnRow = returntable.NewRow();
            for (int nColumn = 0; nColumn < 10; nColumn++)
            {
                //Note you will probably get conversion problems here that you will have to handle
                returnRow[nColumn] = xlWorksheet.Rows[nRow].ItemArray[nColumn];
            }
            returntable.Rows.Add(returnRow);
        }
    }

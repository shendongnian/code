        public System.Data.DataTable CorruptedExcel(string path, string savedFile) {
        try
        {
            Missing missing = Missing.Value;
           Excel.Application excel = new Excel.Application();
           Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(path, CorruptLoad: Microsoft.Office.Interop.Excel.XlCorruptLoad.xlRepairFile);
            var connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text\"";
            //var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                var sheets = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [" + sheets.Rows[0]["TABLE_NAME"].ToString() + "] ";
                    var adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        catch (Exception e)
        {
            throw new Exception("ReadingExcel: Excel file could not be read! Check filepath.\n"
                + e.Message + e.StackTrace);
        }
    }
    

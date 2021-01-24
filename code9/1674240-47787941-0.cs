        internal static bool SheetExist(string fullFilePath, string sheetName)
        {
            var connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=NO'",fullFilePath)
            var excelSheetName = "'" + sheetName + "$'";
            using (OleDbConnection excelCon = new OleDbConnection(connString))
            {
                excelCon.Open();
                try
                {
                    var dtSheets = excelCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dtSheets == null) return false;
                    var sheetList = dtSheets.Select().ToList();
                    return sheetList.Any(sheet => sheet["TABLE_NAME"].ToString() == excelSheetName);
                }
                finally
                {
                    excelCon.Close();
                }
            }
        }

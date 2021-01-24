        [TestMethod]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|\\data.xlsx;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=false", "Sheet1$", DataAccessMethod.Sequential)] // This is working Excel.xlsx connection!!! Excel (ODBC, Dsn)
        public void ExcelReadWrite()
        {
            //Open copied Excel file and create Excel object
            string projectName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string dir = Environment.CurrentDirectory + @"\..\..\..\";
            string targetFilename = "newdata.xlsx";
            string targetFile = dir + projectName + @"\" + targetFilename;
            object missing = Type.Missing;
            object misValue = System.Reflection.Missing.Value;
            Excel.Application excel = new Excel.Application();
            Excel.Workbook wb = excel.Workbooks.Open(targetFile, true, false);
            Excel.Worksheet ws = wb.Sheets[1];
            Excel.Range wr = ws.UsedRange;
            int rowCount = wr.Rows.Count;
            int colCount = wr.Columns.Count;
            //make some example data update for current iteration 
            int row = TestContext.DataRow.Table.Rows.IndexOf(TestContext.DataRow); //current iteration data row. zero base
            int generatedData = Convert.ToInt32(TestContext.DataRow[0]) + Convert.ToInt32(TestContext.DataRow[1]); //read from DataSource
            ws.Cells[row + 2, 3] = generatedData; //Worksheet, not zero base, and header row counts
            // ======================================================
            ws = wb.ActiveSheet;
            excel.DisplayAlerts = false;
            wb.SaveAs(targetFile, Excel.XlFileFormat.xlWorkbookDefault, misValue,
                                                 misValue, misValue, misValue,
                                                 Excel.XlSaveAsAccessMode.xlExclusive, misValue,
                                                 misValue, misValue, misValue, misValue);
            wb.Close(missing, missing, missing);
            excel.Quit();
        }

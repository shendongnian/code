    var frmDialog = new System.Windows.Forms.OpenFileDialog();
            if (frmDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                /*string strFileName = frmDialog.FileName;
                //System.IO.FileInfo spreadSheetFile = new System.IO.FileInfo(strFileName);
                System.IO.StreamReader reader = new System.IO.StreamReader(strFileName);
                */
                
                string strFileName = frmDialog.FileName;
                FileStream stream = File.Open(strFileName, FileMode.Open, FileAccess.Read);
                //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                //...
                //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                //...
                //3. DataSet - The result of each spreadsheet will be created in the result.Tables
                //DataSet result = excelReader.AsDataSet();
                //...
                //4. DataSet - Create column names from first row
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet result = excelReader.AsDataSet();
                DataTable data = result.Tables[0];
                //5. Data Reader methods
                while (excelReader.Read())
                {
                    //excelReader.GetInt32(0);
                }
                scheduleGridView.DataSource = data;
                excelReader.Close();

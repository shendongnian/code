        public void ReciveData(string headers, string data)
        {
            #region Read Data
            List<string> tbl_Headers = new List<string>();
            List<List<string>> tbl_Data = new List<List<string>>();
            tbl_Headers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(headers);
            tbl_Data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<string>>>(data);
            #endregion
            #region Create Data Table
            DataTable dataTable = new DataTable("Data");
            foreach (var prop in tbl_Headers)
            {
                dataTable.Columns.Add(prop);
            }
            DataRow row;
            foreach (var rw in tbl_Data)
            {
                row = dataTable.NewRow();
                for (int i = 0; i < rw.Count; i++)
                {
                    row[tbl_Headers[i]] = rw[i];
                }
                dataTable.Rows.Add(row);
            }
            #endregion
            #region Save To excel
            string path = @"D:\";
            string fileName = "";
            GenerateExcelSheetWithoutDownload(dataTable, path, out fileName); 
            #endregion
        }
        public bool GenerateExcelSheetWithoutDownload(DataTable dataTable, string exportingSheetPath, out string exportingFileName)
        {
            #region Validate the parameters and Generate the excel sheet
            bool returnValue = false;
            exportingFileName = Guid.NewGuid().ToString() + ".xls";
            if (dataTable != null && dataTable.Rows.Count > new int())
            {
                string excelSheetPath = string.Empty;
                #region Check If The directory is exist
                if (!Directory.Exists(exportingSheetPath))
                {
                    Directory.CreateDirectory(exportingSheetPath);
                }
                excelSheetPath = exportingSheetPath + exportingFileName;
                FileInfo fileInfo = new FileInfo(excelSheetPath);
                #endregion
                #region Write stream to the file
                MemoryStream ms = DataToExcel(dataTable);
                byte[] blob = ms.ToArray();
                if (blob != null)
                {
                    using (MemoryStream inStream = new MemoryStream(blob))
                    {
                        FileStream fs = new FileStream(excelSheetPath, FileMode.Create);
                        inStream.WriteTo(fs);
                        fs.Close();
                    }
                }
                ms.Close();
                returnValue = true;
                #endregion
            }
            return returnValue;
            #endregion
        }
        private static MemoryStream DataToExcel(DataTable dt)
        {
            MemoryStream ms = new MemoryStream();
            using (dt)
            {
                #region Create File
                HSSFWorkbook workbook = new HSSFWorkbook();//Create an excel Workbook
                ISheet sheet = workbook.CreateSheet("data");//Create a work table in the table
                int RowHeaderIndex = new int();
                #endregion
                
                #region Table Headers
                IRow headerTableRow = sheet.CreateRow(RowHeaderIndex);
                if (dt != null)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        headerTableRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);
                    }
                    RowHeaderIndex++;
                }
                #endregion
                #region Data
                foreach (DataRow row in dt.Rows)
                {
                    IRow dataRow = sheet.CreateRow(RowHeaderIndex);
                    foreach (DataColumn column in dt.Columns)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    }
                    RowHeaderIndex++;
                }
                #endregion
                workbook.Write(ms);
                ms.Flush();
                //ms.Position = 0;
            }
            return ms;
        }

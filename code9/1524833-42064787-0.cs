        /// <summary>
        /// Function to write database content in excel sheet.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="localFileName"></param>
        public void WriteDataToExcel(string tableName, string localFileName)
        {
            SqlConnection conn = new SqlConnection(sqlConnection);
            object misValue = System.Reflection.Missing.Value;
            FileExcel.Application xlApp = new FileExcel.Application();
            FileExcel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue); ;
            FileExcel.Worksheet xlWorkSheet = (FileExcel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            try
            {
                //Read data from database.
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from " + tableName + "", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                string data = null;
                int headerRowTotal = 0;
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        xlWorkSheet.Cells[i + 1, j + 1] = ds.Tables[0].Columns[j].ToString();
                    }
                    headerRowTotal++;
                }
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[headerRowTotal + i + 1, j + 1] = data;
                    }
                }
                //Check and delte file if already exist.
                if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), localFileName)))
                {
                    //Delete file.
                    File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), localFileName));
                }
                xlWorkBook.SaveAs(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), localFileName), FileExcel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, FileExcel.XlSaveAsAccessMode.xlShared, FileExcel.XlSaveConflictResolution.xlUserResolution, true, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
        }
        /// <summary>
        /// Function to release object of excel files.
        /// </summary>
        /// <param name="obj"></param>
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception err)
            {
                obj = null;
                MessageBox.Show(err.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

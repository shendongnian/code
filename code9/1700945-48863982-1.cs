        private void ExportDataSetToExcel(DataSet ds)
        {
            //Creae an Excel application instance
            Excel.Application excelApp = new Excel.Application();
           Excel.Workbook excelWorkBook = excelApp.Workbooks.Add(); 
            foreach (DataTable table in ds.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;
    
                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }
    
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }
     //save the Excel workbook
            excelWorkBook.Saveas("C:\\SSRS\\TFSWorkitem.xlsx", 
                Excel.XlSaveAsAccessMode.xlNoChange);
            excelWorkBook.Close();
            excelApp.Quit();
        }

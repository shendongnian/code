        private void delete_Click(object sender, EventArgs e)
        {
            //create excel
            Excel.Application xlexcel = new Excel.Application();
            Excel.Workbook xlWorkBook = xlexcel.Workbooks.Open(@"C:\\SAMPLE.xlsx");
            int[] Cols = { 1 };
            Excel.Range curRange;
            foreach (Excel.Worksheet sheet in xlWorkBook.Worksheets)
            {
                foreach (Excel.Range row in sheet.UsedRange.Rows)
                {
                    foreach (int c in Cols)
                    {
                        curRange = (Excel.Range)row.Cells[1, 1];
                        if (curRange.Cells.Value != null)
                        {      
                             if (employeeBox.SelectedItem.Equals(sheet.Cells[row.Row, c].Value.ToString()))
                             { 
                                row.EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                                MessageBox.Show("Employee Deleted.");
                             }
                        }
                    }
                }
            }
                 xlexcel.DisplayAlerts = false;
                xlWorkBook.SaveAs("C:\\SAMPLE.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Type.Missing,
                Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlWorkBook.Close();
                xlexcel.Quit();
                releaseObject(xlexcel);
                releaseObject(xlWorkBook);
                
            
        }

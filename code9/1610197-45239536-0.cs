        private static void excelFile(System.Data.DataTable dtTable, List<Dictionary<string, object>> list)
        {
            // File save dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.FileName = null;
            saveFileDialog.Title = "Save path of the file to be exported";
            
            //string filepath = AppDomain.CurrentDomain.BaseDirectory;
            Excel.Application xlApp = null;
            Excel.Workbooks wkbooks = null;
            Excel.Workbook wkbook = null;
            Excel.Sheets wksheets = null;
            Excel.Worksheet wksheet = null;
            try
            {
                xlApp = new Excel.Application();
                wkbooks = xlApp.Workbooks;
                wkbook = wkbooks.Add();
                wksheets = wkbook.Sheets;
                wksheet = wksheets.Add();
           
                Console.WriteLine(list[0].Values);
                wksheet.Name = "APPLE";
                try
                {
                Console.WriteLine("It is working.");
                for (var i = 0; i < dtTable.Columns.Count; i++)
                {
                    wksheet.Cells[1, i + 1] = dtTable.Columns[i].ColumnName;
                }
                //rows
                    for (var i = 0; i < dtTable.Rows.Count; i++)
                    {
                        for (var j = 0; j < dtTable.Columns.Count; j++)
                        {
                            wksheet.Cells[i + 2, j + 1] = dtTable.Rows[i][j];
                        }
                    }
                //wkbook.SaveAs(saveFileDialog, XlFileFormat.xlExcel8,false,
                //false, false,false, XlSaveAsAccessMode.xlNoChange, Type.Missing,
                //Type.Missing, Type.Missing,Type.Missing, Type.Missing);
                    Console.WriteLine("Processing!");
                    Console.WriteLine("File saved.");
    
                    wkbooks.Close();
                    wkbook.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();      
               
                }
                catch(Exception exp)
                {
                   
                }
             }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
            }
            finally
            {
                if (wksheets != null) Marshal.ReleaseComObject(wksheets);
                if (wkbook != null) Marshal.ReleaseComObject(wkbook);
                if (wkbooks != null) Marshal.ReleaseComObject(wkbooks);
                if (xlApp != null) Marshal.ReleaseComObject(xlApp);
            }
        }
    }
 

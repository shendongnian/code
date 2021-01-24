    private void sample()
                {
        
                    string p1 = @"C:\\EXCEL\\DATA\\data" + System.DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".xls";
                    //System.IO.FileInfo objFileInfo = new System.IO.FileInfo(p1);
                    //StreamWriter wr = new StreamWriter(p1);
                    cmd = new OracleCommand("here is my query", con);
                    DataTable dt = new DataTable();
                    DataSet DS = new DataSet();
                    OracleDataAdapter AD = new OracleDataAdapter(cmd);
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);
                    da.Fill(DS);
        
                    ExportToExcel(DS.Tables[0], p1);
                }   
        
                public void ExportToExcel( DataTable dtCollection,string savingFileName)
                {
                    var ds = dtCollection;
                    Microsoft.Office.Interop.Excel.Worksheet objWorkSheet1 = null;
                    Microsoft.Office.Interop.Excel.Application objExcel = new Microsoft.Office.Interop.Excel.Application { Visible = false };
                    Microsoft.Office.Interop.Excel.Workbooks objWorkbooks = objExcel.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook objWorkbook = objWorkbooks.Add(Missing.Value);
                    Microsoft.Office.Interop.Excel.Sheets objSheets = objWorkbook.Worksheets;
                    Microsoft.Office.Interop.Excel.Range objCells;
                    Microsoft.Office.Interop.Excel.Range myCell;
                    var iCurrentRow = 10;
                    var dt = ds;
                    int columnsCount = dt.Columns.Count;
                    objWorkSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)(objSheets[1]);
                    objCells = objWorkSheet1.Cells;
        
                    for (var h = 0; h < dt.Columns.Count; h++)
                    {
                        myCell = (Microsoft.Office.Interop.Excel.Range)objCells[iCurrentRow, h + 1];
                        myCell.Value2 = dt.Columns[h].ColumnName;
                    }
                    iCurrentRow++;
                    for (var r = 0; r < dt.Rows.Count; r++)
                    {
                        for (var c = 0; c < dt.Columns.Count; c++)
                        {
                            if (dt.Columns[c].DataType.Name == "String" || dt.Columns[c].DataType.Name == "DateTime")
                            {
                                myCell = (Microsoft.Office.Interop.Excel.Range)objCells[r + iCurrentRow, c + 1];
                                myCell.Value2 = "'" + dt.Rows[r][c].ToString().Trim();
                            }
                            else
                            {
                                myCell = (Microsoft.Office.Interop.Excel.Range)objCells[r + iCurrentRow, c + 1];
                                myCell.Value2 = dt.Rows[r][c];
                            }
                        }
                    }
                    objWorkSheet1.Cells.EntireRow.AutoFit();
                    objWorkSheet1.Cells.EntireColumn.AutoFit();
                    objWorkbook.SaveAs(savingFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value);
                    objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                    objExcel.Quit();
                }

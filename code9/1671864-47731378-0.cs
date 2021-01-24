        enter code here
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Excel = Microsoft.Office.Interop.Excel;
    using log4net;
    using System.Data;
    using System.Diagnostics;
    
    namespace ReadAppendExcel
    {
        public static class DataTable_Extensions
        {
            /// <summary>
            /// Export DataTable to Excel file
            /// </summary>
            /// <param name="DataTable">Source DataTable</param>
            /// <param name="ExcelFilePath">Path to result file name</param>
            private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            public static void ExportToExcel(this System.Data.DataTable DataTable, string ExcelFilePath = null)
            {
                log4net.Config.BasicConfigurator.Configure();
                ILog log = log4net.LogManager.GetLogger(typeof(Program));
                try
                {
                    int ColumnsCount;
                    log.Info("In the ExportToExcel function");
                    if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                        throw new Exception("ExportToExcel: Null or empty input table!\n");
    
                    // load excel, and create a new workbook
                    Excel.Application Excel = new Excel.Application();
                    Excel.Workbooks.Add();
                    // single worksheet
                    Excel._Worksheet Worksheet = Excel.ActiveSheet;
                    int RowsCount = DataTable.Rows.Count;
                    object[] Header = new object[ColumnsCount];
                    object[] RowsCol = new object[RowsCount];
                    // column headings               
                    for (int i = 0; i < ColumnsCount; i++)
                        Header[i] = DataTable.Columns[i].ColumnName;
                    // DataCells
                    Excel.Range range;
                    object[,] Cells = new object[RowsCount, ColumnsCount];
                    //Excel.Range range = Worksheet.get_Range((Excel.Range)(Worksheet.Cells[RowsCount, ColumnsCount]), (Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount]));
                    //range.Value = RowsCol;
                    for (int j = 0; j <= RowsCount-1; j++)
                    {
                        for (int i = 0; i < ColumnsCount; i++)
                        {
                            Cells[j, i] = DataTable.Rows[j][i];
                            if (DataTable.Rows[j][1].ToString() == "Failed")  // CHECKING CONDITION WITH THE DATATABLE
                            {
                                  range = Worksheet.get_Range((Excel.Range)(Worksheet.Cells[j+1, i + 1]), (Excel.Range)(Worksheet.Cells[j+1, i + 1]));
                                  range.Interior.Color = ColorTranslator.ToOle(Color.Red);
                            }
                            else if (DataTable.Rows[j][1].ToString() == "Running")
                            {
                                range = Worksheet.get_Range((Excel.Range)(Worksheet.Cells[j + 1, i + 1]), (Excel.Range)(Worksheet.Cells[j + 1, i + 1]));
                                range.Interior.Color = ColorTranslator.ToOle(Color.Yellow);
                            }
                            else if (DataTable.Rows[j][1].ToString() == "Interrupted")
                            {
                                range = Worksheet.get_Range((Excel.Range)(Worksheet.Cells[j + 1, i + 1]), (Excel.Range)(Worksheet.Cells[j + 1, i + 1]));
                                range.Interior.Color = ColorTranslator.ToOle(Color.Yellow);
                            }
                            else if (DataTable.Rows[j][1].ToString() == "Succeeded")
                            {
                                range = Worksheet.get_Range((Excel.Range)(Worksheet.Cells[j + 1, i + 1]), (Excel.Range)(Worksheet.Cells[j + 1, i + 1]));
                                range.Interior.Color = ColorTranslator.ToOle(Color.White);
                            }
                        }
                    }
                    Excel.Range HeaderRange = Worksheet.get_Range((Excel.Range)(Worksheet.Cells[1, 1]), (Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
                    HeaderRange.Value = Header;
                    HeaderRange.Interior.Color = ColorTranslator.ToOle(Color.Orange);
                    HeaderRange.Font.Bold = true;
                    range = Worksheet.get_Range((Excel.Range)(Worksheet.Cells[2, 1]), (Excel.Range)(Worksheet.Cells[RowsCount, ColumnsCount]));
                    Worksheet.get_Range((Excel.Range)(Worksheet.Cells[2, 1]), (Excel.Range)(Worksheet.Cells[RowsCount, ColumnsCount])).Value = Cells;
                    range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Color = Color.Black.ToArgb();
                    range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Color = Color.Black.ToArgb();
                    range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Color = Color.Black.ToArgb();
                    range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Color = Color.Black.ToArgb();
                    range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Color = Color.Black.ToArgb();
                    range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Color = Color.Black.ToArgb();
                    range.Columns.AutoFit();
                    // check fielpath
                    if (ExcelFilePath != null && ExcelFilePath != "")
                    {
                        try
                        {
                            Worksheet.SaveAs(ExcelFilePath);                        
                            Excel.Quit();
                            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(Worksheet);
                            GC.Collect();
                            Process[] excelProcesses = Process.GetProcessesByName("excel");
                            foreach (Process p in excelProcesses)
                            {
                                if (string.IsNullOrEmpty(p.MainWindowTitle)) // use MainWindowTitle to distinguish this excel process with other excel processes 
                                {
                                    p.Kill();
                                }
                            }
                            DataTable.Dispose();
                            log.Info("excel successfully created");
                        }
                        catch (Exception ex)
                        {
                            log.Info("ExportToExcel: Excel file could not be saved! Check filepath.\n" + ex.Message.ToString());
                            throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                + ex.Message);
                        }
                    }
                    else    // no filepath is given
                    {
                        Excel.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    log.Info("ExportToExcel: \n" + ex.Message.ToString());
                    throw new Exception("ExportToExcel: \n" + ex.Message);
                }
            }
        }
    }

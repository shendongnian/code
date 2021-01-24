    using System;
    using System.Collections.Generic;
    using System.Data;
    using Microsoft.Office.Interop.Excel;
    using DataTable = System.Data.DataTable;
    
    namespace ExcelExample
    {
        internal class Test
        {
            private int _cnt1 = 0;
            private readonly List<DataTable> _dataTables = new List<DataTable>();
    
            private void button1_Click(object sender, EventArgs e)
            {
                ReadDataFromDatabase();
                ExportToExcel();
                DataRefresh();
            }
    
            private void ReadDataFromDatabase()
            {
                try
                {
                    if (_cnt1 >= 1)
                    {
                        _dataTables.Clear();
                        connectionSilca();
                        for (int counter = 0; counter < _cnt1; counter++)
                        {
                            fcl.cmd = new OracleCommand(
                                "select book_id,book_title,category_id,author,book_pub,book_copies,publisher_name,isbn,copyright_year,date_added,status from book where book_id='" +
                                listBox1.Items[counter].ToString() + "'", fcl.con);
    
                            var dataSet = new DataSet();
    
                            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);
                            oracleDataAdapter.Fill(dataSet);
                            _dataTables.Add(dataSet.Tables[0]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Atleast One Item");
                    }
                }
                catch (Exception)
                {
                    // catch any connection exceptions.
                }
                finally
                {
                    con.Close();
                }
            }
    
            private void ExportToExcel()
            {
                //open the excel file form the location 
                //here is existing excel code
                const string path = @"C:\\EXCEL\\DATA\\myData.xls";
                var excelApplication = new Application(){Visible = false, DisplayAlerts = false};
                var workbook = excelApplication.Workbooks.Open(path, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                var workSheet = workbook.Worksheets["Input"] as Worksheet;
    
                if (workSheet != null)
                {
                    workSheet.Cells[5, 3] = 100000089;
                    workSheet.Cells[5, 4] = 001;
                    workSheet.Cells[5, 7] = System.DateTime.Now.ToString("ddMMyyyy");
                    workSheet.Cells[5, 10] = "ASHSBCTS2017";
    
                    var cells = workSheet.Cells;
                    var rowIndex = 12;
    
                    foreach (var table in _dataTables)
                    {
                        for (var r = 0; r < table.Rows.Count; r++)
                        {
                            for (var c = 0; c < table.Columns.Count; c++)
                            {
                                var currentCell = (Range)cells[rowIndex, c + 1];
    
                                if (table.Columns[c].DataType.Name == "String" || table.Columns[c].DataType.Name == "DateTime")
                                {
                                    currentCell.Value2 = "'" + table.Rows[r][c].ToString().Trim();
                                }
                                else
                                {
                                    currentCell.Value2 = table.Rows[r][c];
                                }
                            }
                            rowIndex++;
                        }
                    }
                }
    
                workbook.SaveAs("C:\\EXCEL\\DATA\\myData.xls", XlFileFormat.xlExcel12, System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value, false, false, XlSaveAsAccessMode.xlShared, false, false,
                    System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                workbook.Close();
                excelApplication.Quit();
    
                MessageBox.Show("EXCEL DOWNLOAD SUCCESSFULLY");
            }
        }
    }

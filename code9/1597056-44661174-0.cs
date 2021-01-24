    private void createXLSXFromDataTable(System.Data.DataTable table, string path)
            {
                MemoryStream ms = new MemoryStream();
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("data");
                    worksheet.Cells["A1"].LoadFromDataTable(table,true);
                    worksheet.Column(1).Style.Numberformat.Format = "dd/mm/yyyy\\ hh:mm";
                    worksheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    byte[] excelData = package.GetAsByteArray();
                    ms.Write(excelData, 0, excelData.Length);
                }
                ms.Flush();
                using (FileStream fs = File.Create(pfad))
                {
                    ms.WriteTo(fs);
                }
                //open again with ms office, 
                //so the file will get saved correctly and
                //all columns have the correct format
                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                application.Visible = false;
                Workbooks wbooks = application.Workbooks;
                wbooks.Open(pfad, Origin: XlPlatform.xlWindows);
                Workbook wbook = application.ActiveWorkbook;
                wbook.Save();
                //quitting the services,
                //after that delete/stop COM-connections of each object
                wbook.Close();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wbook);
                wbooks.Close();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wbooks);
                application.Quit();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(application);
                MessageBox.Show("Document successfully created.");
            }

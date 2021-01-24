    using (ExcelPackage testFile = new ExcelPackage(new System.IO.FileInfo(@"c:\Data\test.xlsx")))
                {
                    ExcelWorksheet testSht = testFile.Workbook.Worksheets[1];
    
                    testSht.Cells[1, 1].Value = new DateTime(2017, 1, 1);
                    testSht.Cells[2, 1].Style.Numberformat.Format = "dd-mm-yyyy";
                    testSht.Cells[2, 1].Formula = "=Date(" + DateTime.Now.Year + "," + DateTime.Now.Month + "," + DateTime.Now.Day + ")";
                    testSht.Cells[3, 1].Value = new DateTime(2017, 1, 1);
                    testSht.Cells[3, 1].Style.Numberformat.Format = "dd.MM.yyyy";
                    testFile.Save();
                }

        private void FantasyExcelCalculateCellValue(string[] number, string cnums, string filePath)
        {
            string fc = "";
            string sc = "";
            int ifounded = 0;
            Excel.Workbook xlWorkBook;
            objexcel = new Excel.Application();
            object misValue = System.Reflection.Missing.Value;
            if (cnums == "1")
            { fc = "A2"; sc = "F2"; }
            if (cnums == "2")
            { fc = "G2"; sc = "L2"; }
            if (cnums == "3")
            { fc = "M2"; sc = "R2"; }
            string sr1 = "";
            string fr1 = "";
            string ov1 = fc.Remove(0, 1);
            string sr2 = "";
            string fr2 = "";
            string ov2 = sc.Remove(0, 1);
            objexcel.DisplayAlerts = false;
            objexcel.AutoCorrect.AutoExpandListRange = false;
            xlWorkBook = objexcel.Workbooks.Open(filePath, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, true, 0, true, 1, 0);
            xlWorkBook.CheckCompatibility = false;
            Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range exRange = (Excel.Range)xlWorkSheet.get_Range(fc, sc);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            // Put another loop i from 2 to 500 and for each i increase range like A2 + 1 (A3) F2 + 1 (F3)
            for (int i = 2; i < 502; i++)
            {
                sr1 = i.ToString();
                sr2 = i.ToString();
                fr1 = fc.Replace(ov1, sr1);
                fr2 = sc.Replace(ov2, sr2);
                exRange = (Excel.Range)xlWorkSheet.get_Range(fr1, fr2);
                int mj = 0;
                ifounded = 0;
                for (int m = 0; m < number.Length; m++)
                    {
                        Excel.Range currentFind = null;
                        Excel.Range firstFind = null;
                        // You should specify all these parameters every time you call this method,
                        // since they can be overridden in the user interface. 
                        currentFind = exRange.Find(number[m], misValue, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, true, misValue, misValue);
                        while (currentFind != null)
                        {
                            // Keep track of the first range you find. 
                            if (firstFind == null)
                            {
                                firstFind = currentFind;
                            }
                            // If you didn't move to a new range, you are done.
                            else if (currentFind.get_Address(Excel.XlReferenceStyle.xlA1) == firstFind.get_Address(Excel.XlReferenceStyle.xlA1))
                            {
                                break;
                            }
                        
                        int p = 0;
                        if (cnums == "1")
                        {
                            p = 6;
                        }
                        if (cnums == "2")
                        {
                            p = 12;
                        }
                        if (cnums == "3")
                        {
                            p = 18;
                        }
                        string icolor = currentFind.Interior.Color.ToString();
                        if (icolor == "65535")
                        {
                            ifounded++;
                            if (ifounded > 3)
                            {
                                xlWorkSheet.Cells[i, p] = ifounded.ToString();
                                Excel.Range range = xlWorkSheet.get_Range(fr2, fr2) as Excel.Range;
                                range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                range.Font.Bold = true;
                                range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            }
                        }
                        currentFind = exRange.FindNext(currentFind);
                        }
                        mj++;
                }
            }
            xlWorkBook.SaveAs(@filePath, misValue,
                misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlNoChange,
                misValue, misValue, misValue, misValue, misValue);
            xlWorkBook = objexcel.Workbooks.Add(misValue);
            xlWorkBook.Close(true, misValue, misValue);
            objexcel.Quit();
            releaseObject(xlWorkBook);
        }

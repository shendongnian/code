            Microsoft.Office.Interop.Excel.Application oXL;
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = false;
            oXL.IgnoreRemoteRequests = true;
            oXL.DisplayAlerts = false;
            Workbook oWB;
            Workbooks wbs = oXL.Workbooks; //Never use two dots, since the middle one needs free as well
            oWB = wbs.Open(path, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Marshal.ReleaseComObject(wbs);
            
            Sheets excelSheets = oWB.Worksheets;
            string currentSheet = "PC_HW_Info";
            Worksheet excelWorksheet = excelSheets.get_Item(currentSheet);
            string columnRange;
            int rowsNumber = 2;
            Range PC_User;
            PC_User = excelWorksheet.get_Range("A2", "A2"); // Need to free
            while ((PC_User.Value2) != null)
            {
                ++rowsNumber;
                columnRange = "A" + rowsNumber;
                
                Marshal.ReleaseComObject(PC_User);
                PC_User = excelWorksheet.get_Range(columnRange, columnRange);
            }
            PC_User.Value2 = "aaaa";
            Marshal.ReleaseComObject(PC_User);
            oXL.UserControl = false;
            oWB.SaveAs("valid path to my file", XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            oWB.Close();
            Marshal.ReleaseComObject(excelWorksheet);
            Marshal.ReleaseComObject(excelSheets);
            Marshal.ReleaseComObject(oWB);
            oXL.Quit();
            Marshal.ReleaseComObject(oXL);

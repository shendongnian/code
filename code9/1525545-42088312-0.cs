        string saveasPath = "YOUR_PATH";
        xlWorkBook.SaveAs("" + saveasPath + ".xlsx");
        xlWorkBook.Close(true, misValue, misValue);
        xlApp.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);            
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
        xlWorkSheet = null;
        xlWorkBook = null;
        xlApp = null;
        GC.Collect();
            

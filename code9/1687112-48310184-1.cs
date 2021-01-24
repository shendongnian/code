      try
            {               
                string startPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                string filePath_source = Path.Combine(startPath, @"Source_Files\Offers_Source_Temp.xlsx");
                string filePath_copiedinto = Path.Combine(startPath, @"Source_Files\ToBeCopiedInto.xlsx");
               app = new Excel.Application();
               app.DisplayAlerts = false;
               book = app.Workbooks.Open(filePath_source);
                sheet = (Excel.Worksheet)book.Worksheets.get_Item((1));              
                int iRowCount = sheet.UsedRange.Rows.Count;              
                int countColumns = sheet.UsedRange.Columns.Count;
                int maxrows = 10;//change this to something like 50,000 later.  01/16/18
                int maxloops = iRowCount / maxrows;
                int beginrow = 2; //skipping the header row.
                Excel.Application destxlApp;
                Excel.Workbook destworkBook;
                Excel.Worksheet destworkSheet;
                Excel.Range destrange;
                string srcPath;
                string destPath;
                //Opening of first worksheet and copying
                srcPath = filePath_source;
                for (int i = 1; i <= maxloops; i++)   {
                    ///  Excel.Range rng = (Excel.Range)sheet.Range[sheet.Cells[beginrow, 1], sheet.Cells[maxrows, 3]];
                    Excel.Range startCell = sheet.Cells[beginrow, 1];//not sure the second parameter needed?
                    Excel.Range endCell = sheet.Cells[beginrow+maxrows-1, 3];//not sure the second parameter needed?
                    Excel.Range rng = sheet.Range[startCell, endCell];
                    rng = rng.EntireRow;//so second parameters above should not be needed. But doesn't work without it!
                    rng.Copy(Type.Missing);
                    //opening of the second worksheet and pasting
                    destPath = filePath_copiedinto; 
                    destxlApp = new Excel.Application();
                    destxlApp.DisplayAlerts = false;
                    destworkBook = destxlApp.Workbooks.Open(destPath, 0, false);
                    destworkSheet = destworkBook.Worksheets.get_Item(1);
                    destrange = destworkSheet.Cells[1, 1];
                    destrange.Select();
                    destworkSheet.Paste(Type.Missing, Type.Missing);                   
                    destworkBook.SaveAs(startPath + "\\Output_Files\\" + beginrow + ".xlsx");                    
                    destworkBook.Close(true, null, null);
                    destxlApp.Quit();
                    beginrow = beginrow + maxrows;
                   
                }//for loop
    }

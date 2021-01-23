    using (ExcelPackage pck = new ExcelPackage())
    {
        //Create the worksheet
        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Demo");
        //Load the datatable into the sheet, starting from cell A1. 
        //Print the column names on row 1
        //Apply the Dark1 style
        ws.Cells["A1"].LoadFromDataTable(tbl, true, TableStyles.Dark1);
        
        pck.SaveAs(new FileInfo(@"c:\temp\MyFile.xlsx"));
    }

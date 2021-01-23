    Workbook workbook = new Workbook();
    workbook.LoadFromFile(@"C:\your_path_here\SampleFile.xlsx");
    Worksheet sheet = workbook.Worksheets[0];
    sheet.Name = "Data Source";
    Worksheet sheet2 = workbook.CreateEmptySheet();
    sheet2.Name = "Pivot Table";
    CellRange dataRange = sheet.Range["A1:G200000"];
    PivotCache cache = workbook.PivotCaches.Add(dataRange);
    PivotTable pt = sheet2.PivotTables.Add("Pivot Table", sheet.Range["A1"], cache);
    var r1 = pt.PivotFields["Vendor No"];
    r1.Axis = AxisTypes.Row;
    pt.Options.RowHeaderCaption = "Vendor No";
    
    var r2 = pt.PivotFields["Description"];
    r2.Axis = AxisTypes.Row;
    pt.DataFields.Add(pt.PivotFields["OnHand"], "SUM of OnHand", SubtotalTypes.Sum);
    pt.DataFields.Add(pt.PivotFields["OnOrder"], "SUM of OnOrder", SubtotalTypes.Sum);
    pt.DataFields.Add(pt.PivotFields["ListPrice"], "Average of ListPrice", SubtotalTypes.Average);
    
    pt.BuiltInStyle = PivotBuiltInStyles.PivotStyleMedium12;
    workbook.SaveToFile("PivotTable.xlsx", ExcelVersion.Version2010);
    System.Diagnostics.Process.Start("PivotTable.xlsx");

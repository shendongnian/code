    Workbook wb = new Workbook("source.xlsx");
    Worksheet ws = wb.Worksheets[0];
    PivotTable pt = ws.PivotTables[0];
    PivotField pdf = pt.DataField;
    pt.AddFieldToArea(PivotFieldType.Column, pt.DataField);
    pt.RefreshData();
    pt.CalculateData();
    wb.Save("output.xlsx");

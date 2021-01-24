    ExcelPackage pck = new ExcelPackage();
    var ws = pck.Workbook.Worksheets.Add("Sample1");
    ws.Cells["A1"].Value = "Sample 1";
    ws.Cells["A1"].Style.Font.Bold = true;
    var shape = ws.Drawings.AddShape("Shape1", eShapeStyle.Rect);
    shape.SetPosition(50, 200);
    shape.SetSize(200, 100);
    shape.Text = "Sample 1 saves to the Response.OutputStream";
    pck.SaveAs(Response.OutputStream);

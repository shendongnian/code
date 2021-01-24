    //Create workbook
    Workbook wb = new Workbook();
    //Access first worksheet
    Worksheet ws = wb.Worksheets[0];
    //Add some value in cell A1
    Cell cell = ws.Cells["A1"];
    cell.PutValue(22);
    //Format cell A1 with TRL formatting
    Style st = cell.GetStyle();
    st.Custom = "[$TRL]\\ #,##0.00";
    cell.SetStyle(st);
    //Make the entire column C with TRL formatting
    StyleFlag flg = new StyleFlag();
    flg.NumberFormat = true;
    ws.Cells.Columns[2].ApplyStyle(st, flg);
    //Now enter data in column C cells
    ws.Cells["C5"].PutValue(31);
    ws.Cells["C6"].PutValue(32);
    ws.Cells["C7"].PutValue(33);
    ws.Cells["C8"].PutValue(34);
    //Save the workbook
    wb.Save("output.xlsx");

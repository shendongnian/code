    Excel.Workbook myBook = xlApp.Workbooks.Open(@"path\excel.xlsx");
    Excel.Worksheet ws = myBook.Worksheets[1];
    // You can use all dynamic ranges instead
    // Excel.Range xlRng = ws.Range[ws.Cells[yourRow, firsColumn], ws.Cells[yourRow, lastColumn]];
    Excel.Range xlRng = ws.Range["A1:D1"];
    xlRng.FormulaR1C1 = "=MATCH(R[-1]C,Sheet2!R2C2:$R5C2,0)";
    xlRng.Calculate();
    xlRng.Value = xlRng.Value;

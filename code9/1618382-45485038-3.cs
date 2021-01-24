    Excel.Workbook myBook = xlApp.Workbooks.Open(@"path\excel.xlsx");
    Excel.Worksheet ws = myBook.Worksheets[1];
    Excel.Range xlRng = ws.Range["A1:D1"]; // ws.Range[ws.Cells[yourRow, firsColun], ws.Cells[yourRow, endColumn]];
    xlRng.FormulaR1C1 = "=MATCH(R[-1]C,Sheet2!R2C2:$R5C2,0)";
    xlRng.Calculate();
    xlRng.Value = xlRng.Value;

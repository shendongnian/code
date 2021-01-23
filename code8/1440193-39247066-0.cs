    public override void AddExcelRows(string[] bufData, int cReport, int cSection, int nrow, bool insertRow)
    {
        int rowIndex;
        int colIndex;
        rowIndex = //some number
        colIndex = //some number
        Sheet sheet = wbPart.Workbook.Descendants<Sheet>().Where((s) => s.Name == currentSheetName).FirstOrDefault();
        WorksheetPart worksheetPart = wbPart.GetPartById(sheet.Id) as WorksheetPart;
        SharedStringTablePart shareStringPart = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
        SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
        for (int colOffset = 0; colOffset <= some number; colOffset++)
        {
            if (bufData[colOffset] != null)
            {
                int index = InsertSharedStringItem(bufData[colOffset], shareStringPart);
                var columnName = GetExcelColumnName(colIndex + colOffset);
                Cell cell = InsertCellInWorksheet(columnName, rowIndex, worksheetPart);
                if (cell.CellValue !=null && cell.CellValue.InnerText == bufData[colOffset])//if same value is already present in current cell then skip writign again. it was causing issue writng [kW] for project Technical report.
                {
                    continue; 
                }
                cell.CellValue = new CellValue(index.ToString());
                cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
            }
        }
        if (insertRow)
        {
            uint nextRowIndex = (uint)rowIndex + 1; //Add min 3 rows in excel with styles (border line)
            Row oldRow = sheetData.Elements<Row>().Where(r => r.RowIndex == nextRowIndex).First();
            var newRow = oldRow.CopyToLine((uint)nextRowIndex, sheetData);
        }
        wbPart.Workbook.Save();
    }   

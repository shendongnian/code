    foreach(Row row in sheetData.Elements<Row>)
    {
        foreach(Cell cell in row.Elements<Cell>)
        {
        if(cell.CellReference == DesiredCell)
            {
            cell = new Cell(new CellValue(“ ”)) { DataType = CellValues.String, StyleIndex = 1 };
            }
        }
    }

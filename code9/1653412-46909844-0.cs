    private void AddCellToRow(Row row, string value, string cellReference)
    {
        //the cell might already exist, if it does we should use it.
        Cell cell = row.Descendants<Cell>().FirstOrDefault(c => c.CellReference == cellReference);
        if (cell == null)
        {
            cell = new Cell();
            cell.CellReference = cellReference;
        }
        cell.CellValue = new CellValue(value);
        cell.DataType = CellValues.String;
        row.Append(cell);
    }

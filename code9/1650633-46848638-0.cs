    public static Cell getCellByReference(string cellReference, Worksheet ws)
    {
        return ws.Descendants<Cell>().Where(c => c.CellReference.Value == cellReference).FirstOrDefault();
    }
    Cell myCell = getCellByReference("A1", actualWorksheet)

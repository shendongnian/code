    Table table = new Table();
    foreach (var collateral in universalDTO.Collaterals)
    {
    Span span = new Span("First Column");
    Paragraph paragraph = new Paragraph();
    paragraph.Inlines.Add(span);
    Span span2 = new Span("Second Column");
    Paragraph paragraph2 = new Paragraph();
    paragraph2.Inlines.Add(span2);
    TableCell cell = new TableCell();
    cell.Blocks.Add(paragraph);
    TableCell cell2 = new TableCell();
    cell2.Blocks.Add(paragraph2);
    TableRow row = new TableRow();
    row.Cells.Add(cell);
    row.Cells.Add(cell2);
    table.AddRow(row);
    }

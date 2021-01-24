    var selectedCells = this.Grid.Selected.Cells;
    // Loop through selected cells and put them in "edit mode" (actually, show plain text)
    foreach (var cell in selectedCells)
    {
        Console.WriteLine(cell.CellDisplayStyle);
        cell.CellDisplayStyle = CellDisplayStyle.PlainText;                
    }
    // Execute copy command
    this.Grid.PerformAction(UltraGridAction.Copy, false, false);
    // Loop through selected cells and bring them back to original state
    foreach (var cell in selectedCells)
    {
        Console.WriteLine(cell.CellDisplayStyle);
        cell.CellDisplayStyle = CellDisplayStyle.Default;
    }

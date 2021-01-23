    // Remove any existing content at this position in the grid
    foreach (var existingContent in (from cell in tabGrid1.Children where Grid.GetRow(cell) == rowIndex && Grid.GetColumn(cell) == colIndex select cell).ToArray())
    {
        tabGrid1.Children.Remove(existingContent);
    }
    
    // add the new content
    tabGrid1.Children.Add(wrap1);

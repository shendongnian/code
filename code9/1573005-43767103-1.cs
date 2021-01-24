    List<List<GridCellItem>> buttonGrid = new List<List<GridCellItem>>();
    for (int r = 0; r < Rows; r++)
    {
        buttonGrid.Add(new List<GridCellItem>());
        for (int c = 0; c < Cols; c++)
        {
            buttonGrid[r].Add(new GridCellItem(r, c));
        }
    }
    Field.ItemsSource = buttonGrid;

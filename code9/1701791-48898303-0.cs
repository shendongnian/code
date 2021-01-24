    int rows = AllTiles.GetLength(0);
    int cols = AllTiles.GetLength(1);
    int indRow = 0;
    int indCol = 0;
    foreach (Tile t in AllTilesOneDim) {
        indRow = t.indRow;
        indCol = t.indCol;
        if (indRow >= 0 && indRow < rows
            && indCol >= 0 && indCol < cols)
        {
            // Fill 2D Array AllTiles
            AllTiles[indRow, indCol] = t;
        }
    }

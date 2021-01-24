    for (int j = 0; j < RowCount - 1; j++)
    {
        for (int k = 0; k < ColumnCount - 1; k++)
        {
            GridCell currentCell = GetCurrentCell (Slice1, Slice2, j, k);
            System.Threading.Thread t = new System.Threading.Thread(()=>
            Polygonise (ref Triangles, isoLevel, currentCell));
            t.Start();
        }
    }

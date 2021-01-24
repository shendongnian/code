    Enumerable
      .Range(0, RowCount)
      .AsParallel()
      .ForAll(j => {
           for (int k = 0; k < ColumnCount - 1; k++)
           {
               GridCell currentCell = GetCurrentCell (Slice1, Slice2, j, k);
               Polygonise (ref Triangles, int isoLevel, GridCell currentCell);
           } 
       });

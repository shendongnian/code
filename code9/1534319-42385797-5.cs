    Enumerable
      .Range(0, RowCount)
      .AsParallel()
      // .WithDegreeOfParallelism(4) // <- if you want to tune PLinq
      .ForAll(j => {
           for (int k = 0; k < ColumnCount - 1; k++)
           {
               GridCell currentCell = GetCurrentCell (Slice1, Slice2, j, k);
               // Beware! Possible race condition: 
               // "ref Triangles" is shared reference between threads. 
               Polygonise (ref Triangles, int isoLevel, GridCell currentCell);
           } 
       });

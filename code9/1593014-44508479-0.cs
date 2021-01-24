    using System.Linq; 
    ...
    class Grid {  
      private Cell[][] grid; // it's null when not initialized      
      public Grid(int rows, int cols, bool initialState) {
        if (rows < 0)
          throw new ArgumentOutOfRangeException("rows");
        else if (cols < 0)
          throw new ArgumentOutOfRangeException("cols");
        // we want grid be a jagged array: with "rows" lines each of "cols" items  
        grid = Enumerable
          .Range(0, rows)
          .Select(r => new Cell[cols])
          .ToArray(); 
        for(int row = 0; row < rows; row++){
          for (int col = 0; col < cols; col++) {
            int id = (row + 1) * rows - (rows - col);
            grid[row][col] = new Cell(row, col, id, initialState);
          }
        } 
      }
     ....

    private string GetCommaDelimitedRow(DataGridView grid, int rowIndex) {
      StringBuilder sb = new StringBuilder();
      for (int curCol = 0; curCol < grid.Columns.Count; curCol++) {
        if (rowIndex < 0)
          sb.Append(grid.Columns[curCol].Name);
        else {
          if (grid.Rows[rowIndex].Cells[curCol].Value != null) {
            sb.Append(grid.Rows[rowIndex].Cells[curCol].Value.ToString());
          }
          else {
            sb.Append("");
          }
        }
        // if this col is not the last column... add a delimiter ','
        if (curCol < grid.Columns.Count - 1)
          sb.Append(",");
      }
      return sb.ToString();
    }

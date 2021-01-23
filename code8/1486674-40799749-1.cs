    private void SetRowColorBasedOnColValue(int valueToCompare, int colIndex, Color color)
    {
      foreach (DataGridViewRow row in dataGridView1.Rows)
      {
        if (row.Cells[colIndex] != null && row.Cells[colIndex].Value != null)
        {
          int cellValue = GetIntValue(row.Cells[colIndex].Value.ToString());
          if (cellValue >= valueToCompare)
          {
            row.DefaultCellStyle.BackColor = color;
          }
          else
          {
            row.DefaultCellStyle.BackColor = Color.White;
          }
        }
        else
        {
          // null cell
          row.DefaultCellStyle.BackColor = Color.White;
        }
      }
    }
    private int GetIntValue(string inString)
    {
      int returnValue = 0;
      if (int.TryParse(inString, out returnValue))
        return returnValue;
      return returnValue;
    }

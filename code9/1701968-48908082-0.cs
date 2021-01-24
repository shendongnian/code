    static void SetCellStyle(Range cells, Color color, int row,int col)
        {
          cells[row, col].Style.Border.Top.Color.SetColor(color);
          cells[row, col].Style.Border.Top.Style= ExcelBorderStyle.Thin;
          cells[row, col].Style.Border.Left.Color.SetColor(color);
          cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
          cells[row, col].Style.Border.Right.Color.SetColor(color);
          cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
          cells[row, col].Style.Border.Bottom.Color.SetColor(color); 
          cells[row, col].Style.Border.Bottom.Style= ExcelBorderStyle.Thin;
        }

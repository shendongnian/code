    private void SetValues(var CurrentSheet, int row, int col)
    {
       CurrentSheet.Cells[row, col].Style.Border.Top.Color.SetColor(Color.Red);
       CurrentSheet.Cells[row, col].Style.Border.Top.Style= ExcelBorderStyle.Thin;
       CurrentSheet.Cells[row, col].Style.Border.Left.Color.SetColor(Color.Red);
       CurrentSheet.Cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
       CurrentSheet.Cells[row, col].Style.Border.Right.Color.SetColor(Color.Red);
       CurrentSheet.Cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
       CurrentSheet.Cells[row, col].Style.Border.Bottom.Color.SetColor(Color.Red);
       CurrentSheet.Cells[row, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
    }

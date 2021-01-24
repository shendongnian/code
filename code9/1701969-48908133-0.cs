        private static void SetBorder(int row, int col)
        {
            var border = ExcelWorkSheet.Cells[row, col].Style.Border;
            border.Top.Color.SetColor(Color.Red);
            border.Top.Style = ExcelBorderStyle.Thin;
            border.Left.Color.SetColor(Color.Red);
            border.Left.Style = ExcelBorderStyle.Thin;
            border.Right.Color.SetColor(Color.Red);
            border.Right.Style = ExcelBorderStyle.Thin;
            border.Bottom.Color.SetColor(Color.Red);
            border.Bottom.Style = ExcelBorderStyle.Thin;
        }

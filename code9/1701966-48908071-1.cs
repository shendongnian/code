     private void SetValues(int StyleType, var CurrentSheet, int row, int col)
    {
        switch (StyleType)
        {
            case 1:
                //add style if its 1 (this could be for important items as you mentioned)
                break;
            case 2:
                //a different style
                break;
            case 3:
                //I'll use your example here to give you more context
                CurrentSheet.Cells[row, col].Style.Border.Top.Color.SetColor(Color.Red);
                CurrentSheet.Cells[row, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                CurrentSheet.Cells[row, col].Style.Border.Left.Color.SetColor(Color.Red);
                CurrentSheet.Cells[row, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                CurrentSheet.Cells[row, col].Style.Border.Right.Color.SetColor(Color.Red);
                CurrentSheet.Cells[row, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                CurrentSheet.Cells[row, col].Style.Border.Bottom.Color.SetColor(Color.Red);
    
    
                CurrentSheet.Cells[row, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                break;
        }
    }
   

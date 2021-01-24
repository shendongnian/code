     private void TrimEmptyRows(ExcelWorksheet worksheet)
        {
            //loop all rows in a file
            for (int i = worksheet.Dimension.Start.Row; i <= 
           worksheet.Dimension.End.Row; i++)
            {
                bool isRowEmpty = true;
                //loop all columns in a row
                for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                {
                    if (worksheet.Cells[i, j].Value != null)
                    {
                        isRowEmpty = false;
                        break;
                    }
                }
                if (isRowEmpty)
                {
                    worksheet.DeleteRow(i);
                }
            }
        } 

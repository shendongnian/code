        for (int iRow = 1; iRow <= iRowCount; iRow++)
        {
            for (int iColumn = 1; iColumn <= iColCount; iColumn++)
            {               
                worksheet.Cells[destinationRange.Start.Row + iRow, 
                destinationRange.Start.Column + iColumn].Value = 
                worksheet.Cells[sourceRange.Start.Row + iRow, 
                sourceRange.Start.Column + iColumn].Value;
            }
        }

        var activeSheet = this.Application.ActiveSheet as Excel.Worksheet;
        if (activeSheet != null)
        {
            var activeCell = activeSheet.Cells[2, 2];
            if (activeCell.MergeCells)
            {
                if (activeCell.MergeArea != null)
                {
                    dynamic mergeAreaValue2 = activeCell.MergeArea.Value2;
                    object[,] vals = mergeAreaValue2 as object[,];
                    if (vals != null)
                    {                            
                        int rows = vals.GetLength(0);
                        int cols = vals.GetLength(1);
                    }                        
                }
            }
        }

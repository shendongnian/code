    public int getLastRow(Excel.Worksheet ws)
    {
        object[,] arData = ws.UsedRange.FormulaR1C1; // FormulaR1C1 returns only string in 2 dimensional array
        for (int iRow = arData.GetUpperBound(0); iRow > 0; iRow--) {
            for (int iCol = 1; iCol <= arData.GetUpperBound(1); iCol++) {
                if (arData[iRow, iCol].ToString() != "") { return iRow; }
            }
        }
        return 0;
    }

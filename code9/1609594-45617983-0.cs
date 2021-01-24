    ...
    ...
    Excel.Range filteredRange = xlrange.SpecialCells(Excel.XlCellType.xlCellTypeVisible,    Excel.XlSpecialCellsValue.xlTextValues);
    for (int areaId = 1; areaId <= filteredRange.Areas.Count; areaId++)
    {
        areaRange = filteredRange.Areas[areaId];
        object[,] areaValues = areaRange.Value;
        for (int row = 0; row < areaValues.GetLength(0); row++)
        {
            // ignore the Header row
            if (areaValues[row + 1, 1].ToString().ToLower() == "id") continue;
            //Add The Row To A List Or Array
         }
    }
                

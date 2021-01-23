    Excel.Range r = exWbk.Worksheets["Sheet1"].Range["A1:C8"];
    Excel.PivotCache pc = exWbk.PivotCaches().Create(
        Excel.XlPivotTableSourceType.xlDatabase, r);
    pivotTb.ChangePivotCache(pc);
    pivotTb.RefreshTable();

    var pch = oBook.PivotCaches();
    Excel.Range pivotData = osheet.Range["A1", "B3"];
    Excel.PivotCache pc = pch.Create(Excel.XlPivotTableSourceType.xlDatabase, pivotData);
    Excel.PivotTable pvt = pc.CreatePivotTable(osheet.Range["A12"], "MyPivotTable");
    pvt.PivotFields("Name").Orientation = Excel.XlPivotFieldOrientation.xlRowField;
    pvt.AddDataField(pvt.PivotFields("Salary"), "Total Salary",
        Excel.XlConsolidationFunction.xlSum);

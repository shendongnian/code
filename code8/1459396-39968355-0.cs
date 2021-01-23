    Range sourceData = _xlBook.Worksheets["Produce Usage by Month"].Range["A6:F94"];
    PivotCache pc = pch.Create(XlPivotTableSourceType.xlDatabase, sourceData);
    PivotTable pvt = pc.CreatePivotTable(sheet2.Range["A1"], "SummaryPivot");
    pvt.PivotFields("Col1").Orientation = XlPivotFieldOrientation.xlRowField;
    pvt.PivotFields("Col2").Orientation = XlPivotFieldOrientation.xlColumnField;
    pvt.AddDataField(pvt.PivotFields("Col3"), "Sum of Col3", XlConsolidationFunction.xlSum);

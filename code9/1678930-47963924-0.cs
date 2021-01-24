    Excel.PivotTables pt = worksheet.PivotTables();
    var pivot = pt.Item(1);
    Microsoft.Office.Interop.Excel.PivotFields vf = pivot.VisibleFields;
                                           // not   pivot.VisibleFields();
    foreach (Microsoft.Office.Interop.Excel.PivotField f in vf)
    {
        // Do something
    }

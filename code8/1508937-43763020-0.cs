    var series = chartObject.Chart.SeriesCollection() as Microsoft.Office.Interop.Excel.SeriesCollection;
    foreach (var ser in series)
    {
        var DataLabels = ((Microsoft.Office.Interop.Excel.Series)ser).DataLabels();
        DataLabels.Format.TextFrame2.TextRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
    }

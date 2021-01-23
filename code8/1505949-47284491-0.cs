    Excel.Series series;
    Excel.SeriesCollection seriesCollection;
    series = seriesCollection.NewSeries();
    var Values = "=Data!$B$2:$B$50";//this is range of columns
    var XValues = "=Data!$A$2:$A$50";//this is range of columns
    series.Name = "series name";
    series.Values = Values;
    series.XValues = XValues;
    series.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;

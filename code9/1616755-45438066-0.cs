    IPresentationChart chart = slide.Charts.AddChart(150, 100, 300, 125); 
    chart.ChartType = OfficeChartType.Column_Stacked; 
    chart.ChartData.SetValue(1, 1, "4355"); 
    chart.ChartData.SetValue(2, 1, "4356"); 
    chart.ChartData.SetValue(3, 1, "4357"); 
    chart.ChartData.SetValue(4, 1, "4358"); 
    chart.ChartData.SetValue(5, 1, "4359"); 
    chart.ChartData.SetValue(1, 2, "6"); 
    chart.ChartData.SetValue(2, 2, "7"); 
    chart.ChartData.SetValue(3, 2, "8"); 
    chart.ChartData.SetValue(4, 2, "9"); 
    chart.ChartData.SetValue(5, 2, "10"); 
    chart.ChartData.SetValue(1, 3, "11"); 
    chart.ChartData.SetValue(2, 3, "12"); 
    chart.ChartData.SetValue(3, 3, "13"); 
    chart.ChartData.SetValue(4, 3, "14"); 
    chart.ChartData.SetValue(5, 3, "15"); 
    //Set data range, Title and category settings 
    chart.PrimaryCategoryAxis.CategoryType = OfficeCategoryType.Category; 
    chart.ChartTitle = ""; 
    chart.ChartArea.Fill.Transparency = 0.5; 
    IOfficeChartSerie serie = chart.Series.Add("date1"); 
    //Selecting data from first row second column to fifth row second column 
    //ChartData[startRow,startColumn,endRow,endColumn] 
    serie.Values = chart.ChartData[1, 2, 5, 2]; 
    serie.SerieType = OfficeChartType.Column_Stacked; 
    IOfficeChartSerie serie2 = chart.Series.Add("date2"); 
    //Selection data from first row third column to fifth row third column 
    serie2.Values = chart.ChartData[1, 3, 5, 3]; 
    serie2.SerieType = OfficeChartType.Column_Stacked; 
    chart.PlotArea.Layout.ManualLayout.Height = 0.9; 
    chart.PlotArea.Layout.ManualLayout.Width = 1; 
    chart.PlotArea.Layout.ManualLayout.Left = 0; 
    chart.PlotArea.Layout.ManualLayout.Top = 0; 
    chart.PrimaryCategoryAxis.CategoryLabels = chart.ChartData[1, 1, 5, 1]; 
    chart.Legend.IncludeInLayout = true; 
    chart.HasLegend = false;

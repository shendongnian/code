     [![Excel.Range chartRange;
    
    
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
                Excel.Chart chartPage = myChart.Chart;
                //диаграмма 2
                chartRange = xlWorkSheet.get_Range("D12", "E16");
                chartPage.SetSourceData(chartRange, misValue);
                chartPage.ChartType = Excel.XlChartType.xl3DPieExploded;
                foreach (Series series in chartPage.SeriesCollection())
                {
                    series.Name = "Уровень удовлетворенности респондентов длительностью ожидания";
                }
                chartPage.HasLegend = true;
               
                //export chart as picture file
                String destPath = Directory.GetCurrentDirectory();
                chartPage.ApplyDataLabels(XlDataLabelsType.xlDataLabelsShowValue, false, true, false, false, false, false, true, false, false);
                 chartPage.Export(Directory.GetCurrentDirectory() + "\\dig2.bmp", "BMP", misValue);
                //конец диаграмы 2][1]][1]
        

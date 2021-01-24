    LiveCharts.SeriesCollection psc = new LiveCharts.SeriesCollection
    {
    	new LiveCharts.Wpf.PieSeries
    	{
    		Values = new LiveCharts.ChartValues<decimal> {1,1},
    	},
    	new LiveCharts.Wpf.PieSeries
    	{
    		Values = new LiveCharts.ChartValues<decimal> {3,7},
    	}
    };
    
    foreach (LiveCharts.Wpf.PieSeries ps in psc)
    {
    	myPieChart.Series.Add(ps);
    }

    private void createNewSeries(String SeriesName)
    {
    	if(chart1.Series.IsUniqueName(SeriesName))
    	{
    		chart1.Series.Add(SeriesName);
    	}
    }
    

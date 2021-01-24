	public SeriesCollection MySeries
	{
		get
		{
			var seriesCollection = new SeriesCollection(mapper);
			seriesCollection.Add(new PieSeries()
			{
				Title = "My display name",
				Values = new ChartValues<YourObjectHere>(new[] { anInstanceOfYourObjectHere })
			});
			return seriesCollection;
		}
	}

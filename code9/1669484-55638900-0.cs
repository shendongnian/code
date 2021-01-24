//using Highsoft.Web.Mvc.Charts; //v7.0.1
Highcharts chart = new Highcharts
{
	ID = "chartid",
	Chart = new Chart
	{
		Type = ChartType.Scatter,
		ZoomType = ChartZoomType.Xy
	},
	Title = new Title
	{
		Text = "example"
	},
	Subtitle = new Subtitle
	{
		Text = "example"
	},
	XAxis = new List<XAxis>
	{
		new XAxis
		{
			Type = XAxisType.Datetime,
			Title = new XAxisTitle
			{
				Text = "Date"
			}
		}
	},
	YAxis = new List<YAxis>
	{
		new YAxis
		{
			Type = YAxisType.Linear,
			Title = new YAxisTitle
			{
				Text = "Value"
			}
		}
	},
	Legend = new Legend
	{
		Align = LegendAlign.Right,
		Enabled = true,
		Layout = LegendLayout.Vertical,
		VerticalAlign = LegendVerticalAlign.Top
	},
	Series = series, //List<Series> adding a SplineSeries for each legend item
};
HighsoftNamespace Highsoft_chart = new HighsoftNamespace();
literal.Text = Highsoft_chart.GetHighcharts(chart, "chartid").ToHtmlString();

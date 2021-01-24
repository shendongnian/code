    // Random Data
    var dia = new Random(100);
    var sys = new Random(10);
    var mon = new Random(9); 
    // Model
    var model = new PlotModel { Title = "ScatterSeries" };
            var scatterSeries = new OxyPlot.Series.ScatterSeries { MarkerType = MarkerType.Circle };
            for (int i = 0; i < 100; i++)
            {
                var x = dia.NextDouble();
                var y = sys.NextDouble();
                var size = mon.NextDouble();
                scatterSeries.Points.Add(new OxyPlot.Series.ScatterPoint(x, y, size * 10));
            } 
            model.Series.Add(scatterSeries);
            model.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Right });
            model.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom });
    //WPF
    var plot = new OxyPlot.Wpf.PlotView() { Model = model };
    this.Content = plot;

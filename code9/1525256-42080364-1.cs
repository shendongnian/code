            //Data:
            int n = 10;
            var dia = new double[10] {1,3,3,4,4,2,4,5,6,4 };
            var sys = new double[10] {2,2,2,4,5,3,4,4,5,6 };
            var mon = Enumerable.Range(1, n).ToArray(); 
            var model = new PlotModel { Title = "ScatterSeries" };
            var scatterSeries = new OxyPlot.Series.ScatterSeries { MarkerType = MarkerType.Circle };
            for (int i = 0; i < n; i++)
            {
                var x = mon[i];
                var y = sys[i];
                var size = dia[i];
                scatterSeries.Points.Add(new OxyPlot.Series.ScatterPoint(x, y, size, size));
            } 
            model.Series.Add(scatterSeries);
            model.Axes.Add(new OxyPlot.Axes.LinearColorAxis { Position = OxyPlot.Axes.AxisPosition.Right, Palette = OxyPalettes.BlueWhiteRed(30) });
            model.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom });
            model.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Left });
            var plot = new OxyPlot.Wpf.PlotView() { Model = model };
            this.Content = plot;

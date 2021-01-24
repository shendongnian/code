    using OxyPlot;
    using OxyPlot.Series;
    using OxyPlot.Axes;
    public class MyViewModel
    {
        public PlotModel Model { get; set; }
        public MyViewModel()
        {
            CategoryAxis xaxis = new CategoryAxis();
            xaxis.Position = AxisPosition.Bottom;
            xaxis.MajorGridlineStyle = LineStyle.Solid;
            xaxis.MinorGridlineStyle = LineStyle.Dot;
            LinearAxis yaxis = new LinearAxis();
            yaxis.Position = AxisPosition.Left;
            yaxis.MajorGridlineStyle = LineStyle.Dot;
            xaxis.MinorGridlineStyle = LineStyle.Dot;
            ColumnSeries s1 = new ColumnSeries();
            s1.IsStacked = true;
            s1.Items.Add(new ColumnItem(20));
            s1.Items.Add(new ColumnItem(60));
            s1.Items.Add(new ColumnItem(40));
            s1.Items.Add(new ColumnItem(50));
            ColumnSeries s2 = new ColumnSeries();
            s2.IsStacked = true;
            s2.Items.Add(new ColumnItem(50));
            s2.Items.Add(new ColumnItem(30));
            s2.Items.Add(new ColumnItem(10));
            s2.Items.Add(new ColumnItem(20));
            Model = new PlotModel();
            Model.Title = "Xamarin Oxyplot Sample";
            Model.Background = OxyColors.Gray;
            Model.Axes.Add(xaxis);
            Model.Axes.Add(yaxis);
            Model.Series.Add(s1);
            Model.Series.Add(s2);
        }
    }

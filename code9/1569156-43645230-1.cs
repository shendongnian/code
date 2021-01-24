    using OxyPlot;
    using OxyPlot.Series;
    public class MyViewModel
    {
        public PlotModel Model { get; set; }
    
        public MyViewModel()
        {
            ColumnSeries s1 = new ColumnSeries();
            s1.IsStacked = true;
            s1.Items.Add(new ColumnItem(20));
            s1.Items.Add(new ColumnItem(80));
            s1.Items.Add(new ColumnItem(40));
            s1.Items.Add(new ColumnItem(60));
    
            ColumnSeries s2 = new ColumnSeries();
            s2.IsStacked = true;
            s2.Items.Add(new ColumnItem(50));
            s2.Items.Add(new ColumnItem(30));
            s2.Items.Add(new ColumnItem(10));
            s2.Items.Add(new ColumnItem(20));
    
            Model = new PlotModel();
            Model.Series.Add(s1);
            Model.Series.Add(s2);
        }
    }

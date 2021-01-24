    using OxyPlot;
    using OxyPlot.Series;
    using System.Windows;
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PlotModel Model
        {
            get; set;
        }
    
        public MainWindow()
        {
            DataContext = this;
    
            Model = new PlotModel
            {
                Title = "Test",
                TitlePadding = 0,
                TitleFontSize = 24
            };
            LineSeries line = new LineSeries();
            line.Points.Add(new DataPoint(0, 0));
            line.Points.Add(new DataPoint(1, 1));
            line.Points.Add(new DataPoint(2, 2));
            Model.Series.Add(line);
        }
    }

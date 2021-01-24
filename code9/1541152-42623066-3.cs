    public partial class MainWindow : Window
    { 
        PlotModel plotModel;
        public MainWindow()
        {
            InitializeComponent(); 
            plotModel = new PlotModel { Title = "OxyPlot" };
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom });
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Left, Maximum = 10, Minimum = 0 });
            var series1 = new OxyPlot.Series.LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White
            };
            series1.Points.Add(new DataPoint(0, 6));
            series1.Points.Add(new DataPoint(1, 2));
            series1.Points.Add(new DataPoint(2, 4));
            series1.Points.Add(new DataPoint(3, 2));
            series1.Points.Add(new DataPoint(4, 7));
            series1.Points.Add(new DataPoint(6, 6));
            series1.Points.Add(new DataPoint(8, 8));
            series1.Smooth = true;
            plotModel.Series.Add(series1);
            this.Content = new OxyPlot.Wpf.PlotView() { Model = plotModel  };
            plotModel.MouseDown += PlotModel_MouseDown;
        }
        private void PlotModel_MouseDown(object sender, OxyMouseDownEventArgs e)
        {
            var s = plotModel.Series[0] as LineSeries; // asuming that there is just one line series
            ListBox list = new ListBox();
            list.Style = (Style)TryFindResource("listOfPoint");
            list.ItemsSource = s.Points; 
            Window win = new Window() { Content = list, Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner }; // You can display the results in a Popup too
            win.ShowDialog(); // You might call Show() instead.
        }  
    }

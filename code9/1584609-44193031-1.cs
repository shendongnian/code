    public partial class MainWindow : Window
    {
        public PlotModel Model { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Model = new PlotModel();
            
            var axis1 = new LinearColorAxis();
            axis1.Key = "ColorAxis";
            axis1.Maximum = 2 * Math.PI;
            axis1.Minimum = 0;
            axis1.Position = AxisPosition.Top;
            Model.Axes.Add(axis1);
            
            var s1 = new ScatterSeries();
            s1.ColorAxisKey = "ColorAxis";
            s1.MarkerSize = 8;
            s1.MarkerType = MarkerType.Circle;
            for (double x = 0; x <= 2 * Math.PI; x += 0.1)
                s1.Points.Add(new ScatterPoint(x, Math.Sin(x), double.NaN, x));
            Model.Series.Add(s1);
            DataContext = this;
        }
    }

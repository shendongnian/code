    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawGraphs();
        }
        public void DrawGraphs()
        {
            LineSeries mySeries = new LineSeries
            {
                Values = new ChartValues<int> { 12, 23, 55, 1 }
            };
            myChart.Series.Add(mySeries);
        }
    }

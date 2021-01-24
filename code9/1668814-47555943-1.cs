    public partial class LiveView : Window
    {
        private const int DataPointsToShow = 100;
        public Tuple<LinkedList<double>, LinkedList<double>> GraphData = new Tuple<LinkedList<double>, LinkedList<double>>(new LinkedList<double>(), new LinkedList<double>());
        public Timer GraphDataTimer;
        public LiveView()
        {
            InitializeComponent();
            GraphDataTimer = new Timer(50);
            GraphDataTimer.Elapsed += GraphDataTimer_Elapsed;
        }
        private void GraphDataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random random = new Random();
            if (GraphData.Item1.Count() > DataPointsToShow)
            {
                GraphData.Item1.RemoveFirst();
                GraphData.Item2.RemoveFirst();
            }
            GraphData.Item1.AddLast(random.NextDouble()*200);
            GraphData.Item2.AddLast(DateTime.Now.ToOADate());
            Dispatcher.Invoke(() =>
            {
                linegraph.Plot(GraphData.Item1, GraphData.Item2);
            });
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GraphDataTimer.Enabled)
            {
                GraphDataTimer.Stop();
            }
            else
            {
                GraphDataTimer.Start();
            }
        }
    }

    namespace POC_WPF_UserControlExample
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private DispatcherTimer _timer = null;
            private GraphPen _graphPen0 = null;
            private Int32 _pos = 0;
            private PathFigure _pathFigure0 = null;
            private bool _firstTime = true;
    
            public MainWindow()
            {
                InitializeComponent();
    
                _pathFigure0 = new PathFigure();
                _graphPen0 = new GraphPen();
                _graphPen0.PenLineColor = Brushes.DarkGoldenrod;
                _graphPen0.PenLineThickness = 2;
                _graphPen0.PenGeometry = new PathGeometry();
                _graphPen0.PenGeometry.Figures.Add(_pathFigure0);
                myExample.GraphPens.Add(_graphPen0);
    
                _timer = new DispatcherTimer();
                _timer.Tick += Timer_Tick;
                _timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
                _timer.Start();
            }
    
            private void Timer_Tick(object sender, EventArgs e)
            {
                _pos++;
                Point penPoint0 = new Point(_pos, _pos + 20);
                if (_firstTime)
                {
                    myExample.GraphPens[0].PenGeometry.Figures[0].StartPoint = penPoint0;
                    _firstTime = false;
                }
                else
                {
                    LineSegment segment = new LineSegment(penPoint0, true);
                    myExample.GraphPens[0].PenGeometry.Figures[0].Segments.Add(segment);
                }
    
                myExample.DebugText = _pos.ToString();
            }
        }
    }

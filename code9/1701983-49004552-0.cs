        LinesVM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new LinesVM();
            vm.Lines = new ObservableCollection<test1.MainWindow.LinePoints>();
            SolidColorBrush col = new SolidColorBrush(Colors.Red);
            vm.Lines.Add(new LinePoints(1, 5, col));
            vm.Lines.Add(new LinePoints(10, 15, col));
            vm.Lines.Add(new LinePoints(41, 45, col));
            vm.Lines.Add(new LinePoints(71, 85, col));
            DataContext = vm;
        }
        public class LinesVM
        {
            private ObservableCollection<LinePoints> _lines;
            public ObservableCollection<LinePoints> Lines
            {
                get { return _lines; }
                set
                {
                    if (_lines == value)
                        return;
                    _lines = value;
                }
            }
        }
        public class LinePoints:INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
            public LinePoints(double x, double y, SolidColorBrush color)
            {
                X = x;
                Y = y;
                Color = color;
            }
            private SolidColorBrush _color;
            public SolidColorBrush Color
            {
                get { return _color; }
                set
                {
                    if (_color == value)
                        return;
                    _color = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Color)));
                }
            }
            private double _x1;
            public double X1
            {
                get { return _x1; }
                set
                {
                    if (_x1 == value)
                        return;
                    _x1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(X1)));
                }
            }
            private double _x2;
            public double X2
            {
                get { return _x2; }
                set
                {
                    if (_x2 == value)
                        return;
                    _x2 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(X2)));
                }
            }
            private double _y1;
            public double Y1
            {
                get { return _y1; }
                set
                {
                    if (_y1 == value)
                        return;
                    _y1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Y1)));
                }
            }
            private double _y2;
            public double Y2
            {
                get { return _y2; }
                set
                {
                    if (_y2 == value)
                        return;
                    _y2 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Y2)));
                }
            }
            private double _y;
            public double Y
            {
                get { return _y; }
                set
                {
                    if (_y == value)
                        return;
                    _y = value;                    
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Y)));
                    Y1 = Y - 2;
                    Y2 = Y + 2;
                }
            }
            private double _x;
            public double X
            {
                get { return _x; }
                set
                {
                    if (_x == value)
                        return;
                    _x = value;                    
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(X)));
                    X1 = X - 2;
                    X2 = X + 2;
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SolidColorBrush col = new SolidColorBrush(Colors.Black);
            vm.Lines.Add(new LinePoints(21, 25, col));
            vm.Lines.Add(new LinePoints(210, 215, col));
            vm.Lines.Add(new LinePoints(241, 145, col));
            vm.Lines.Add(new LinePoints(171, 185, col));
            vm.Lines[1].Color = col;
        }

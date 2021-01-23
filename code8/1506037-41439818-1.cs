        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public Point TestPoint
        {
            get
            {
                return (Point)GetValue(TestPointProperty);
            }
            set
            {
                SetValue(TestPointProperty, value);
            }
        }
        // Using a DependencyProperty as the backing store for TestPoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TestPointProperty =
            DependencyProperty.Register("TestPoint", typeof(Point), typeof(MainWindow), new PropertyMetadata(new Point(1.0, 1.0)));
         public Point TestPoint2
        {
            get
            {
                return (Point)GetValue(TestPoint2Property);
            }
            set
            {
                SetValue(TestPoint2Property, value);
            }
        }
        // Using a DependencyProperty as the backing store for TestPoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TestPoint2Property =
            DependencyProperty.Register("TestPoint2", typeof(Point), typeof(MainWindow), new PropertyMetadata(new Point(1.0, 1.0)));
    }
    public class PointConverter : IValueConverter
    {
        double knownX = 0.0;
        double knownY = 0.0;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
             if (parameter.ToString() == "x")
            {
                knownX = ((Point)value).X;
                return ((Point)value).X;
            }
            else
            {
                knownY = ((Point)value).Y;
                return ((Point)value).Y;
            }
           
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
             Point p = new Point();
            if (parameter.ToString() == "x")
            {
                p.Y = knownY;
                p.X = double.Parse(value.ToString());
            }
            else
            {
                p.X = knownX;
                p.Y = double.Parse(value.ToString());
            }
            return p;
        }
    }

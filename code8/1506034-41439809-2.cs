    public partial class MainWindow : Window
    {
        public Point TestPoint
        {
            get { return (Point)GetValue(TestPointProperty); }
            set { SetValue(TestPointProperty, value); }
        }
        
        public double TestPointX
        {
            get { return this.TestPoint.X; }
            set
            { 
                SetValue(TestPointProperty, new Point(value, this.TestPointY);
            }
        }
        public double TestPointY
        {
            get { return this.TestPoint.Y; }
            set
            { 
                SetValue(TestPointProperty, new Point(this.TestPointX, value);
            }
        }
        
        public static readonly DependencyProperty TestPointProperty = DependencyProperty.Register("TestPoint", typeof(Point), typeof(MainWindow), new PropertyMetadata(new Point(1.0, 1.0)));
    }

    public partial class MainWindow : Window
    {
        private Ellipse elip = new Ellipse();
        private Point anchorPoint;
        public MainWindow()
        {
            InitializeComponent();
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += canvas_MouseUp;
            canvas.MouseDown += canvas_MouseDown;
        }
        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //capture the mouse on the canvas
            //(this also helps us keep track of whether or not we're drawing)
            canvas.CaptureMouse();
            anchorPoint = e.MouseDevice.GetPosition(canvas);
            elip = new Ellipse
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            canvas.Children.Add(elip);
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //if we are not drawing, we don't need to do anything when the mouse moves
            if (!canvas.IsMouseCaptured)
                return;
            Point location = e.MouseDevice.GetPosition(canvas);
            double minX = Math.Min(location.X, anchorPoint.X);
            double minY = Math.Min(location.Y, anchorPoint.Y);
            double maxX = Math.Max(location.X, anchorPoint.X);
            double maxY = Math.Max(location.Y, anchorPoint.Y);
            Canvas.SetTop(elip, minY);
            Canvas.SetLeft(elip, minX);
            double height = maxY - minY;
            double width = maxX - minX;
            
            elip.Height = Math.Abs(height);
            elip.Width = Math.Abs(width);       
        }
        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // we are now no longer drawing
            canvas.ReleaseMouseCapture();
        }
    }

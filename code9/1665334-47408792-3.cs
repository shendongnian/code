    public partial class MainWindow : Window
    {
        Ellipse elip = new Ellipse();
        private Point anchorPoint;
        private bool is_drawing = false;
        public MainWindow()
        {
            InitializeComponent();
            canvas.MouseMove += canvas_PreviewMouseMove;
            canvas.MouseUp += canvas_PreviewMouseUp;
            canvas.MouseDown += canvas_PreviewMouseDown;
        }
        private void canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //keep track of the fact that we are now drawing and will need to do things in the mouse_moved handler
            is_drawing = true;
            anchorPoint = e.MouseDevice.GetPosition(canvas);
            elip = new Ellipse
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            canvas.Children.Add(elip);
        }
        private void canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            //if we are not drawing, we don't need to do anything when the mouse moves
            if (!is_drawing)
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
        private void canvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            // we are now no longer drawing
            is_drawing = false;
        }
    }

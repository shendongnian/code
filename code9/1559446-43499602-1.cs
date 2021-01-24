    public class DrawableCanvas : Canvas
    {
        private Border border;
        static DrawableCanvas()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DrawableCanvas), new FrameworkPropertyMetadata(typeof(DrawableCanvas)));
        }
        // when selection is done expose event to notify the user of selection change
        public DrawableCanvas()
        {
            this.border = new Border();
            border.Background = new SolidColorBrush(Colors.Blue);
            border.BorderThickness = new Thickness(1);
            border.Visibility = Visibility.Hidden;
            border.Opacity = 0.3;
            border.Height = this.ActualHeight;
            this.Children.Add(border);
            this.Background = new SolidColorBrush(Colors.Transparent);
            this.MouseLeftButtonDown += DrawableCanvas_MouseLeftButtonDown;
            this.MouseLeftButtonUp += DrawableCanvas_MouseLeftButtonUp;
            this.MouseMove += DrawableCanvas_MouseMove;
            this.SizeChanged += DrawableCanvas_SizeChanged;
        }
        private void DrawableCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            border.Height = e.NewSize.Height;
        }
        private void DrawableCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Left mouse up");
            // release mouse
            Mouse.Capture(null);
            border.Width = 0;
            startPosition = 0;
        }
        double startPosition = 0;
        private void DrawableCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Left mouse down");
            border.Visibility = Visibility.Visible;
            // capture mouse
            Mouse.Capture(this);
            var point = e.GetPosition(this);
            startPosition = point.X;
            SetLeft(border, point.X);
        }
        private void DrawableCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMouseCaptured)
            {
                var point = e.GetPosition(this);
                Debug.WriteLine("Mouse move");
                // set the position to far left
                SetLeft(border, Math.Min(startPosition, point.X));
                // width is the difference between two points
                border.Width = Math.Abs(startPosition - point.X);
                Debug.WriteLine(Math.Min(startPosition, point.X));
                Debug.WriteLine(border.Width);
            }
        }
    }

    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            this.InitializeComponent(); 
        }
        Point _startPosition;
        bool _isResizing = false;
        private void resizeGrip_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.Capture(resizeGrip))
            {
                _isResizing = true;
                _startPosition = Mouse.GetPosition(this);
            }
        }
        private void window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_isResizing)
            {
                Point currentPosition = Mouse.GetPosition(this);
                double diffX = currentPosition.X - _startPosition.X;
                double diffY = currentPosition.Y - _startPosition.Y;
                double currentLeft = gridResize.Margin.Left;
                double currentTop = gridResize.Margin.Top;
                gridResize.Margin = new Thickness(currentLeft + diffX, currentTop + diffY, 0, 0);
                _startPosition = currentPosition;
            }
        }
        private void resizeGrip_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isResizing == true)
            {
                _isResizing = false;
                Mouse.Capture(null);
            }
        }
    }

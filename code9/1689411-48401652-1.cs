        private bool _isResizing;
        public Manipulator()
        {
            InitializeComponent();
        }
        private void Manipulator_OnManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            if (e.Position.X > Width - ResizeRectangle.Width && e.Position.Y > Height - ResizeRectangle.Height) _isResizing = true;
            else _isResizing = false;
        }
        private void Manipulator_OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (_isResizing)
            {
                Width += e.Delta.Translation.X;
                Height += e.Delta.Translation.Y;
            }
            else
            {
                Canvas.SetLeft(this, Canvas.GetLeft(this) + e.Delta.Translation.X);
                Canvas.SetTop(this, Canvas.GetTop(this) + e.Delta.Translation.Y);
            }
        }

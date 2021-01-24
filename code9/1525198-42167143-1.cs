    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private PointerPoint _devicePointer;
        private FrameworkElement _elementContainingDevicePointer;
        private void MyButton_OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            _elementContainingDevicePointer = sender as FrameworkElement;
            _devicePointer = e.GetCurrentPoint(_elementContainingDevicePointer);
        }
        private void MyButton_OnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            _devicePointer = null;
            _elementContainingDevicePointer = null;
        }
        private void MyToolTip_OnLoaded(object sender, RoutedEventArgs e)
        {
            var tooltip = sender as ToolTip;
            if (_devicePointer != null && _elementContainingDevicePointer != null && tooltip != null)
            {
                var x = _elementContainingDevicePointer.ActualWidth - Math.Max(0, _devicePointer.Position.X);
                var y = _elementContainingDevicePointer.ActualHeight / 2 - Math.Max(0, _devicePointer.Position.Y) - tooltip.ActualHeight / 2;
                tooltip.HorizontalOffset = x + 5;
                tooltip.VerticalOffset = y - 10;
            }
        }
    }

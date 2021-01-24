        private bool _isPressed;
        private void ScrollViewer_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _isPressed = true;
        }
        private void ScrollViewer_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (_isPressed)
            {
                //your logic
            }
        }
        private void ScrollViewer_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            _isPressed = false;
        }
        private void ScrollViewer_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            _isPressed = false;
        }

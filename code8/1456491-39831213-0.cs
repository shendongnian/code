    private void Image_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var border = sender as Border;  
                if (mousePos.X> pos.X|| mousePos.Y > pos.Y)
                {
                    ct.ScaleX *= 1.005;
                    ct.ScaleY *= 1.005;
                }
                if (mousePos.X < pos.X || mousePos.Y < pos.Y)
                {
                    ct.ScaleX /= 1.005;
                    ct.ScaleY /= 1.005;
                }
        }
      private void ImageBorder_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            pos = Window.Current.CoreWindow.PointerPosition;
        }
        private void ImageBorder_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pos = Window.Current.CoreWindow.PointerPosition;
        }

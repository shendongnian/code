       private void OnLeftMouseButtonDown(object sender, MouseButtonEventArgs e) {
            (sender as UIElement).CaptureMouse();
        }
        private void OnLeftMouseButtonUp(object sender, MouseButtonEventArgs e) {
            (sender as UIElement).ReleaseMouseCapture();
        }
        private void OnMouseMove(object sender, MouseEventArgs e) {
            if ((sender as UIElement).IsMouseCaptureWithin) {
                var pos = e.GetPosition(Content);
                BorderThumb.RenderTransform = new TranslateTransform(pos.X, pos.Y);
                BorderToResize.Height = pos.Y;
                BorderToResize.Width = pos.X;
            }
        }

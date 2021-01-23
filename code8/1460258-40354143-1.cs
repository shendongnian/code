        private void imgMusicBlack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var img = sender as Image;
            SetOpacityMask(img, e.GetPosition(img).X);
        }
        private void imgMusicBlack_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var img = sender as Image;
                SetOpacityMask(img, e.GetPosition(img).X);
            }            
        }
        private void SetOpacityMask(Image img, double pointX, double offset = -1)
        {
            if (offset == -1)
                offset = Math.Round(pointX / img.ActualWidth, 2);
                               
            LinearGradientBrush linear = new LinearGradientBrush();
            linear.StartPoint = new Point(0, 0.5);
            linear.EndPoint = new Point(1, 0.5);
            linear.GradientStops = new GradientStopCollection();
            linear.GradientStops.Add(new GradientStop(Colors.Transparent, offset));
            linear.GradientStops.Add(new GradientStop(Colors.Black, offset));
            img.OpacityMask = linear;
        }

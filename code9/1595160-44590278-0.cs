        public Point GetImageCoordsAt(MouseButtonEventArgs e)
        {
            if (child != null && child.IsMouseOver)
            {
                var controlSpacePosition = e.GetPosition(child);
                var imageControl = this.Child as Image;
                var mainViewModel = ((MainViewModel)base.DataContext);
                if (imageControl != null && imageControl.Source != null)
                {
                    // Convert from control space to image space
                    var x = Math.Floor(controlSpacePosition.X * imageControl.Source.Width / imageControl.ActualWidth);
                    var y = Math.Floor(controlSpacePosition.Y * imageControl.Source.Height / imageControl.ActualHeight);
                    return new Point(x, y);
                }
            }
            return new Point(-1, -1);
        }

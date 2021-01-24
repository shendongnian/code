        private void btnRotate_Click(object sender, RoutedEventArgs e)
        {
            double rotation = (double)img.LayoutTransform.GetValue(RotateTransform.AngleProperty);
            rotation += 90;
            img.LayoutTransform.SetValue(RotateTransform.AngleProperty, rotation % 360);
        }

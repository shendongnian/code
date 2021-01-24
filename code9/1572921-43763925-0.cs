    private void Button_Click(object sender, RoutedEventArgs e)
    {
        RotateTransform rotateTransform = indicator1.RenderTransform as RotateTransform;
        DoubleAnimation doubleAnimation = new DoubleAnimation();
        doubleAnimation.From = 0;
        doubleAnimation.To = 360;
        doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(10000));
        doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
        rotateTransform.BeginAnimation(RotateTransform.AngleProperty, doubleAnimation);
    }

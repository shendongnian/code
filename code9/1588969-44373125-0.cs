    private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        LinearGradientBrush lgb = new LinearGradientBrush(
           (Color)ColorConverter.ConvertFromString("#FF1E2838"),
           (Color)ColorConverter.ConvertFromString("#FF2B364F"),
           new Point(0.5, 0),
           new Point(0.5, 1));
        UCBody.Background = lgb;
        ColorAnimation ca1 = new ColorAnimation(
            (Color)ColorConverter.ConvertFromString("#FF1E2838"),
            (Color)ColorConverter.ConvertFromString("#FF1E1E1E"),
            TimeSpan.FromMilliseconds(600));
        ColorAnimation ca2 = new ColorAnimation(
            (Color)ColorConverter.ConvertFromString("#FF2B364F"),
            (Color)ColorConverter.ConvertFromString("#FF2B2B38"),
            TimeSpan.FromMilliseconds(600));
        lgb.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, ca1);
        lgb.GradientStops[1].BeginAnimation(GradientStop.ColorProperty, ca2);
    }

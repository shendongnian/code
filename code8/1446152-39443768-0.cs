    element.RenderTransformOrigin = new Point(0.5, 0.5);
    element.RenderTransform = new RotateTransform();
    var animation = new DoubleAnimation
    {
        To = 9225,
        Duration = TimeSpan.FromSeconds(5.8),
        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
    };
    element.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, animation);

    var rotateTransform = new RotateTransform();
    hand.RenderTransform = rotateTransform;
    hand.RenderTransformOrigin = new Point(0.5, 0.5);
    rotateTransform.BeginAnimation(
        RotateTransform.AngleProperty,
        new DoubleAnimation
        {
            By = 360,
            Duration = TimeSpan.FromSeconds(1),
            RepeatBehavior = RepeatBehavior.Forever
        });

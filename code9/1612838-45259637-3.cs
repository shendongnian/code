    hand.Dispatcher.Invoke(() =>
    {
        hand.RenderTransform.BeginAnimation(
            RotateTransform.AngleProperty,
            new DoubleAnimation(ins_angle, TimeSpan.FromSeconds(1)));
    });

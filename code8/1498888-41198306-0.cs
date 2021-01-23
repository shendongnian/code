    private void PauseAnimation_Click(object sender, RoutedEventArgs e)
    {
        MyStoryboard.Pause();
        CompositeTransform d = Wheel.RenderTransform as CompositeTransform;
        double rotation = d.Rotation;
     }

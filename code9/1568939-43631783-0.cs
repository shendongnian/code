    double currentScale = 1.0;
    private void onMouseWheel_Scroll(object sender, MouseWheelEventArgs e)
    {
        var position = e.MouseDevice.GetPosition(CctvImage);
        var renderTransformValue = CctvImage.RenderTransform.Value;
        if (e.Delta > 0)
        {
            currentScale += 0.1;
        }
        else if (e.Delta < 0)
        {
            currentScale -= 0.1;
            if (currentScale < 1.0)
                currentScale = 1.0;
        }
        CctvImage.RenderTransform = new ScaleTransform(currentScale, currentScale, position.X, position.Y);
    }

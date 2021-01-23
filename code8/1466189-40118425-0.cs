    void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        lastMousePositionOnTarget = Mouse.GetPosition(grid);
        double max = 255;
        double min = .005;
        var deltaScale = Math.Max(Math.Log(scaleTransform.ScaleX), double.Epsilon);
        var delta = e.Delta > 0 ? Math.Max(1 * deltaScale, .5) : Math.Min(1 * deltaScale, -.5);
        double newScale = Math.Max(Math.Min((delta / 250d) + scaleTransform.ScaleX, max), min);
        scaleTransform.ScaleX = newScale;
        scaleTransform.ScaleY = newScale;
        System.Diagnostics.Debug.WriteLine(newScale);
        e.Handled = true;
    }
    

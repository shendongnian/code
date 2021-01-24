    private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var canvas = sender as Canvas;
        if (canvas == null)
            return;
    
        HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, e.GetPosition(canvas));
        var shape = hitTestResult.VisualHit as Shape;
        if (shape == null)
            return;
    
        canvas.Children.Remove(shape);
        shapes.Remove(shape); // I think you don't need list of shapes
    }

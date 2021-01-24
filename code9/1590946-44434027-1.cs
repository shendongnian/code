    private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var canvas = sender as Canvas;
        if (canvas == null)
            return;
        // 1. Find a Path containing links
        HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, e.GetPosition(canvas));
        var path = hitTestResult.VisualHit as Path;
        if (path == null)
            return;
        // 2. Iterate through geometries of the Path and hit test each one
        //    to find a line to delete
        var geometryGroup = path.Data as GeometryGroup;
        if (geometryGroup == null)
            return;
        GeometryCollection geometries = geometryGroup.Children;
        Point point = e.GetPosition(path);
        var pen = new Pen(path.Stroke, path.StrokeThickness);
        var lineToDelete = geometries.OfType<LineGeometry>()
                                     .FirstOrDefault(l => l.StrokeContains(pen, point));
        
        // 3. Delete link
        if (lineToDelete != null)
            geometries.Remove(lineToDelete);
    }

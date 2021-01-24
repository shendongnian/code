    private void CompleteLine(InkUnprocessedInput sender, PointerEventArgs args)
    {
        List<InkPoint> points = new List<InkPoint>();
            InkStrokeBuilder builder = new InkStrokeBuilder();
            InkPoint pointOne = new InkPoint(new Point(line.X1, line.Y1), 0.5f);
            points.Add(pointOne);
            InkPoint pointTwo = new InkPoint(new Point(line.X2, line.Y2), 0.5f);
            points.Add(pointTwo);
            InkStroke stroke = builder.CreateStrokeFromInkPoints(points, System.Numerics.Matrix3x2.Identity);
            InkDrawingAttributes ida = inker.InkPresenter.CopyDefaultDrawingAttributes();
            stroke.DrawingAttributes = ida;
            inker.InkPresenter.StrokeContainer.AddStroke(stroke);
            selectionCanvas.Children.Remove(line);
    }

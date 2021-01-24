    point mousePosition;
    
    private void GraphMouseDown(object sender, MouseButtonEventArgs e)
    {
        CanvasMouseDown = true;
        mousePosition  = e.GetPosition(canvas);
    }
    private void GraphMouseMove(object sender, MouseEventArgs e)
    {
        if (CanvasMouseDown)
        {
            var position = e.GetPosition(canvas);
            var offset = position - mousePosition;
            for (int i = 0; i < GridLinesHoriz.Length; ++i)
            {
                GridLinesHoriz[i].RenderTransform = new TranslateTransform(offset.X, offset.Y);
            }
            for (int i = 0; i < GridLinesVert.Length; ++i)
            {
                GridLinesVert[i].RenderTransform = new TranslateTransform(offset.X, offset.Y);
            }
        }
    }

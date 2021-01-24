    public void CreateCanvas(Canvas parentCanvas,string CanvasName, int height, int width, double xCoord, double yCoord)
    {
        Canvas new_canvas = new Canvas();           
        new_canvas.Name = CanvasName;  //assign Name here    
        new_canvas.Background = new SolidColorBrush(Colors.Red);
        new_canvas.Height = height;
        new_canvas.Width = width;
        Canvas.SetLeft(new_canvas, xCoord);
        Canvas.SetTop(new_canvas, yCoord);
        parentCanvas.Children.Add(new_canvas);
    }

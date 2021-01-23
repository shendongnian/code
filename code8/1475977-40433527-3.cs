    var rect = new System.Windows.Shapes.Rectangle();
    //  Capital C Canvas: Static methods of System.Windows.Canvas, setting what are 
    //  called "attached properties" in WPF. This is very weird if you're new to WPF, sorry. 
    Canvas.SetLeft(rect, 5);
    Canvas.SetTop(rect, 5);
    rect.Height = 5;
    rect.Width = 5;
    //  canvas, lowercase c, is your instance of System.Windows.Canvas
    canvas.Children.Add(rect);
    

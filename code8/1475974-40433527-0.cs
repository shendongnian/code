    var rect = new System.Windows.Shapes.Rectangle();
    //  Static methods of System.Windows.Canvas, setting what are called "attached
    //  properties" in WPF. This is very weird if you're new to WPF, sorry. 
    Canvas.SetLeft(rect, 5);
    Canvas.SetTop(rect, 5);
    //  Instance of System.Windows.Canvas
    myCanvas.Children.Add(rect);
    

        var loc = theUiButton.AbsoluteLocation;
        var p = new System.Drawing.Point(loc.X + 5, loc.Y + 5);
    
        Mouse.DoubleClick(p, MouseButton.Left);
    The reason why it doesn't work right now is because `.DoubleClick`, by default, performs double click in the center of the `UIObject`, and I have a hunch that's not where the expandable object is - so you need to provide fine tuning parameters. 

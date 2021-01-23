    InfoBtn = _utilProvider.FloatingBtn("My Button"); //Returns Floating UIButton
    var dd = new DragDropGestureRecognizer();
    dd.Dragging += (object sender, DragDropEventArgs e) =>
    {
        var view = ((DragDropGestureRecognizer)sender).View;
    
        // Reposition box.
        var x = e.ViewWasAt.X + e.Delta.X;
        var y = e.ViewWasAt.Y + e.Delta.Y;
        view.Center = new CGPoint(x, y);
    };
    InfoBtn.AddGestureRecognizer(dd);
    InfoBtn.TouchUpInside += async (object sender, EventArgs e) =>
    {
        //Button On Click
    };
    InfoBtn.Frame = new CGRect((ScreenWidth / 2) - 22.5, ScreenHeight - 65, 55, 55);
    View.Add(InfoBtn);

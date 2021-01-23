    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        if (!DragIsOn)
        {
            DragIsOn = true;
            MouseOrigin = e.GetPosition(this);
            // I don't know the type of your cam variable so the following is pseudo code
            MouseOrigin.x -= cam.CurrentPosition.x;
            MouseOrigin.y -= cam.CurrentPosition.y;
        }
    }

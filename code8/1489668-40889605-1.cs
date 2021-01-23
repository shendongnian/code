    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (!DragIsOn) return;
        MouseMoved = true;
        var x = (float)(MouseOrigin.X - e.GetPosition(this).x);
        var y = (float) (MouseOrigin.Y - e.GetPosition(this).y);
        cam.MoveCamera(cam.ScreenToWorld(new Vector2(x, y)));
        tmr.Stop();
        tmr.Start();
    }

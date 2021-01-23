    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (!DragIsOn) return;
        MouseMoved = true;
        var x = (float)(e.GetPosition(this).x - MouseOrigin.X);
        var y = (float) (e.GetPosition(this).y - MouseOrigin.Y);
        cam.MoveCamera(cam.ScreenToWorld(new Vector2(x, y)));
        tmr.Stop();
        tmr.Start();
    }

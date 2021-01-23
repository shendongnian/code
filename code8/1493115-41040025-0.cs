    DispatcherTimer timer;
    internal void Regions_Invalidated(CanvasVirtualControl sender, CanvasRegionsInvalidatedEventArgs args)
    {
        // Configure the Mandelbrot effect to position and scale its output. 
        float baseScale = 0.005f;
        float scale = (baseScale * 96 / sender.Dpi) / (helper._modifiers[1] / 1000f);
        var controlSize = baseScale * sender.Size.ToVector2() * scale;
        Vector2 translate = (baseScale * sender.Size.ToVector2() * new Vector2(-0.5f,-0f));
        _effectMandel.Properties["scale"] = scale;
        _effectMandel.Properties["translate"] = (Microsoft.Graphics.Canvas.Numerics.Vector2)translate;
    #endif
        
        // Draw the effect to whatever regions of the CanvasVirtualControl have been invalidated.
        foreach (var region in args.InvalidatedRegions)
        {
            using (var drawingSession = sender.CreateDrawingSession(region))
            {
                drawingSession.DrawImage(_effectMandel);
            }
        }
        
        // start timer for fps
        this.timer = new DispatcherTimer();
        int fps = 60;
        this.timer.Interval = new TimeSpan(0, 0, 0, 0, 100 / fps);
        this.timer.Tick += timer_Tick;
        this.timer.Start();
    }
    private void timer_Tick(object sender, object e)
    {
        this.timer.Stop();
        _canvas.Invalidate();
    }

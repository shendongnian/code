    protected override void OnPaintSurface(SKPaintSurfaceEventArgs args)
    {
        var imgInfo = args.Info;
        var surface = args.Surface;
        var canvas = surface.Canvas;
        var drawBounds = imgInfo.Rect;
        var path = new SKPath();
        var cornerRadius = 5f;
        if (cornerRadius > 0)
        {
            path.AddRoundedRect(drawBounds, cornerRadius, cornerRadius);
        }
        else
        {
            path.AddRect(drawBounds);
        }
        using (var paint = new SKPaint()
        {
            ImageFilter = SKImageFilter.CreateDropShadow(
                                            offsetX,
                                            offsetY,
                                            blurX,
                                            blurY,
                                            color,
                                            SKDropShadowImageFilterShadowMode.DrawShadowOnly),
        })
        {
            canvas.DrawPath(path, paint);
        }
    }

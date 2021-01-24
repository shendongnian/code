    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);
        var regularBrush  = /* regular cell tiled brush */;
        var hoverBrush =  /* hovered cell brush */;
        var fullBounds = new Rect(/* full bounds */);
        var hoverBounds = new Rect(/* bounds of hovered cell */);
        var hasHoveredCell = /* is there a hovered cell? */;
        if (hasHoveredCell)
        {
            // Draw everywhere *except* the hovered cell.
            dc.PushClip(
                Geometry.Combine(
                    new RectangleGeometry(fullBounds),
                    new RectangleGeometry(hoverBounds),
                    GeometryCombineMode.Exclude,
                    Transform.Identity));
        }
        dc.DrawRectangle(regularBrush , null, fullBounds);
        if (hasHoveredCell)
        {
            // Pop the clip and draw the hovered cell.
            dc.Pop();
            dc.DrawRectangle(hoverBrush, null, hoverBounds);
        }
    }

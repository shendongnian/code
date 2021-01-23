    public DrawRectangle(Rectangle r, Color c, float w, Control ct)
    {
        color = c;
        width = w;
        rect = r;
        surface = ct;
        if ((r.Right > surface.Width)  ||  (r.Bottom > surface.Height))
        {
            surface.Size = new Size(Math.Max(surface.Width, r.Right),
                                    Math.Max(surface.Height, r.Bottom)) ;
        }
    }

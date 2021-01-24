    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.FillEllipse(Brushes.DarkGreen, ClientRectangle);
        //TODO: draw text.
    }

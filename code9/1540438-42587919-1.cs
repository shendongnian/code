    protected override void OnPaint(PaintEventArgs pevent)
    {
      base.OnPaint(pevent);
      pevent.Graphics.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(
        new PointF(0, this.Height / 2), new PointF(this.Width, this.Height / 2),
        Color.Red, Color.White), this.ClientRectangle);
    }

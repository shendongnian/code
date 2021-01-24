    using (SolidBrush br = new SolidBrush(Color.FromArgb(192, Color.Silver)))
        g.FillRectangle(br, ClientRectangle);
    StringFormat fmt = new StringFormat()
        { Alignment = StringAlignment.Center,
          LineAlignment = StringAlignment.Center };
    using (SolidBrush br = new SolidBrush(Color.FromArgb(128, Color.Tomato)))
    using (Font f = new Font("Consolas", 40f))
        g.DrawString("PAUSED",f, br, ClientRectangle, fmt);

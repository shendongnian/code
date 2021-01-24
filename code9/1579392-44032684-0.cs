    using (Pen bigPen = new Pen(Color.Black, 3)) {
      e.Graphics.DrawRectangle(bigPen, drawRect);
    }
    using (Font drawFont = new Font(SystemFonts.DefaultFont, FontStyle.Bold)) {
      TextRenderer.DrawText(e.Graphics, "1234562.021", drawFont, drawRect,
                            Color.Black, Color.Empty,
                            TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
    }

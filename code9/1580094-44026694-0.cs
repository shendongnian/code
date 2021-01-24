    public void RemoveSectionFromImage(Bitmap bitmap, Rectangle section, Color color)
    {
        using (Graphics g = Graphics.FromImage(bitmap))
        using (SolidBrush brush = new SolidBrush(color))
        {
            g.FillRectangle(brush, section);
        }
    }

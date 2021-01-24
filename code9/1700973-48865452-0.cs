    public void CenterString(Graphics g, string text, Font font, Color color, int width, int height)
    {
        SizeF sizeF = g.MeasureString(text, font);
        using (SolidBrush solidBrush = new SolidBrush(color))
        {
            g.DrawString(text, font, solidBrush, checked(new Point((int)Math.Round(unchecked(width / 2.0 - (sizeF.Width / 2f))), (int)Math.Round(unchecked(height / 2.0 - (sizeF.Height / 2f))))));
        }
    }

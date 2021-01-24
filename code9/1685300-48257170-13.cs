    if (TheIndexList.Count > 0)
    {
        using (Graphics g = textBox1.CreateGraphics())
        {
            foreach (int Position in TheIndexList)
            {
                PointF pF = textBox1.GetPositionFromCharIndex(Position);
                SizeF sF = g.MeasureString(TheChar.ToString(), textBox1.Font, 0,
                                           StringFormat.GenericTypographic);
                g.FillRectangle(Brushes.LightGreen, new RectangleF(pF, sF));
                using (SolidBrush brush = new SolidBrush(textBox1.ForeColor))
                {
                    g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                    g.DrawString(TheChar.ToString(), textBox1.Font, brush, pF, StringFormat.GenericTypographic);
                }
            }
        }
    }

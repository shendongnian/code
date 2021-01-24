    private void chart_PostPaint(object sender, ChartPaintEventArgs e)
    {
        Graphics g = e.ChartGraphics.Graphics;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        ChartArea ca = chart.ChartAreas[0];
        Font font = ca.AxisX.LabelStyle.Font;
        Color col = ca.AxisX.MajorGrid.LineColor;
        int padding = 10; // pad the labels from the axis
        double aymin = ca.AxisY.Minimum;
        double aymax = ca.AxisY.Maximum;
        int y0 = (int)ca.AxisY.ValueToPixelPosition(aymin);
        int y1 = (int)ca.AxisY.ValueToPixelPosition(aymax);
        foreach (int sx  in stops)
        {
            int x = (int)ca.AxisX.ValueToPixelPosition(chart.Series[0].Points[sx].XValue);
            using (Pen pen = new Pen(col))
                g.DrawLine(pen, x, y0, x, y1);
            string s =  chart.Series[0].Points[sx].XValue + "";
            if (ca.AxisX.LabelStyle.Format != "") s = string.Format(ax.LabelStyle.Format, s);
            SizeF sz = g.MeasureString(s, font, 999);
            g.DrawString(s, font, Brushes.Black, (int)(x - sz.Width / 2) , y0 + padding);
        }
    }

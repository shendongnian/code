    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        if (chart1.Series[0].Points.Count <= 0) return;
        Graphics g = e.ChartGraphics.Graphics;
        ChartArea ca = chart1.ChartAreas[0];
        Rectangle rip = Rectangle.Round(InnerPlotPositionClientRectangle(chart1, ca));
        StringFormat fmt = new StringFormat()
        { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        int cols = chart1.Series[0].Points.Count;
        int sCount = chart1.Series.Count;
        int w = rip.Width / (cols + 1);  // there is ca. 1/2 column gap to the sides
        for (int i = 0; i < cols; i++)
        {
            List<string> s = (List<string>)(chart1.Series[0].Points[i].Tag);
            for (int j = 0; j < s.Count; j++)
            {
                Rectangle r = new Rectangle(rip.Left + i*w + w/2, 
                                            rip.Bottom + 5 + 25 * j, w, 25);
                // 1st row: header, 2nd row sum, rest moved up by and reversed
                using (SolidBrush brush = new SolidBrush(j == 0 ? Color.Transparent
                    : j == 1 ? Color.Gray : chart1.Series[sCount + 1 - j].Color))
                    g.FillRectangle(brush, r);
                g.DrawRectangle(Pens.White, r);
                g.DrawString(s[j], ca.AxisX.LabelStyle.Font, Brushes.White, r, fmt);
            }
        }
    }

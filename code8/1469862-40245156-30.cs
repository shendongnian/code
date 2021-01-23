    void renderLines(List<List<PointF>> data, Graphics graphics, Chart chart, bool curves)
    {
        for (int i = 0; i < chart.Series.Count; i++)
        {
            using (Pen pen = new Pen(Color.FromArgb(64, chart.Series[i].Color), 2.5f))
                if (curves) graphics.DrawCurve(pen, data[i].ToArray());
                else graphics.DrawLines(pen, data[i].ToArray());
        }
    }
    void renderPoints(List<List<PointF>> data, Graphics graphics, Chart chart, float width)
    {
        for (int s = 0; s < chart.Series.Count; s++)
        {
            Series S = chart.Series[s];
            for (int p = 0; p < S.Points.Count; p++)
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(64, S.Color)))
                    graphics.FillEllipse(brush, data[s][p].X-width/2, 
                                         data[s][p].Y-width/2,width, width);
        }
    }

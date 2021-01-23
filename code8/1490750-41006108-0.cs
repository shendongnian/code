    private void chart_PostPaint(object sender, ChartPaintEventArgs e)
    {
        if (e.ChartElement is Series && ((Series)e.ChartElement).Name == "Series3")
        {
            Series s = e.Chart.Series[0];
            ChartGraphics cg = e.ChartGraphics;
            double max = s.Points.FindMaxByValue().YValues[0];
            for (int i = 0; i < s.Points.Count; i++)
            {
                if (s.Points[i].YValues[0] == max)
                {
                    PointF pos = PointF.Empty;
                    pos.X = (float)cg.GetPositionFromAxis("ChartArea1", AxisName.X, s.Points[i].XValue);
                    pos.Y = (float)cg.GetPositionFromAxis("ChartArea1", AxisName.Y, max);
                    pos = cg.GetAbsolutePoint(pos);
                    for (int r = 10; r < 40; r+=10)
                    {
                        cg.Graphics.DrawEllipse(
                            Pens.Red,
                            pos.X - r / 2,
                            pos.Y - r / 2,
                            r, r);
                    }
                }
            }
        }
    }

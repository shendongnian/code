    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        if (checkBox2.Checked)
        {
            int sMax = chart1.Series.Count;
            ChartArea ca = chart1.ChartAreas[0];
            Axis ax = ca.AxisX;
            Axis ay = ca.AxisY;
            ay.Minimum = 0;
            double py0 = ay.ValueToPixelPosition(ay.Minimum);
            Rectangle ipr = Rectangle.Round(InnerPlotPositionClientRectangle(chart1, ca));
            int pMax = chart1.Series[0].Points.Count;
            float shift = (overlap * sMax) / 2f;
            float deltaX = 1f * ipr.Width / (pMax+1);
            float colWidth = 1f * deltaX / sMax;
            for (int j = 0; j < chart1.Series.Count; j++)
                for (int i = 0; i < chart1.Series[j].Points.Count; i++)
                {
                    DataPoint dp = chart1.Series[j].Points[i];
                    double px = ax.ValueToPixelPosition(dp.XValue);
                    double py = ay.ValueToPixelPosition(dp.YValues[0]);
                    using (SolidBrush brush = new SolidBrush(chart1.Series[j].Color))
                        e.ChartGraphics.Graphics.FillRectangle(brush, 
                            (float)px + j * colWidth - deltaX / 2 - overlap * j + shift, 
                            (float)py , colWidth, (float)py0 -  (float)py );
                }
        }
    }

    private void chart_PostPaint(object sender, ChartPaintEventArgs e)
    {
        Series s1 = chart.Series[0];
        ChartArea ca = chart.ChartAreas[0];
        Axis ax = ca.AxisX;
        Axis ay = ca.AxisY;
        Graphics g = e.ChartGraphics.Graphics;
        int iw = imageList1.ImageSize.Width / 2;
        int ih = imageList1.ImageSize.Height / 2;
        foreach (DataPoint dp in s1.Points)
        {
            int x = (int) ax.ValueToPixelPosition(dp.XValue);
            for (int i = 0; i < 6; i++)
            {
                int y = (int) ay.ValueToPixelPosition(dp.YValues[i]);
                g.DrawImage(imageList1.Images[i], x - iw, y - ih);
            }
        }
    }

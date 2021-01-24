    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        Axis ay = chart1.ChartAreas[0].AxisY;
        foreach (var cl in ay.CustomLabels)
        {
            if (cl.RowIndex == 1)
            {
                double vy = (cl.ToPosition + cl.FromPosition) / 2d;
                int y = (int)ay.ValueToPixelPosition(vy);
                e.ChartGraphics.Graphics.DrawString(cl.Text, 
                             cl.Axis.TitleFont, Brushes.DarkRed, 0, y);
            }
        }
    }

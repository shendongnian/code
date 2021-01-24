    private void chart_MouseMove(object sender, MouseEventArgs e)
    {
        HitTestResult hit = chart.HitTest(e.X, e.Y, ChartElementType.AxisLabels);
        if (hit != null && hit.ChartElementType == ChartElementType.AxisLabels)
        {
            var lab = hit.Object as CustomLabel;
            double d = (lab.ToPosition + lab.FromPosition) / 2d;
            DateTime dt = DateTime.FromOADate(d);
            Axis ax = chart.ChartAreas[0].AxisX;
            string tip =  dt.ToString(ax.LabelStyle.Format);
            ax.ToolTip = tip; 
        }
    }

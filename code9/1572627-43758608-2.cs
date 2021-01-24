    private void chart_MouseMove(object sender, MouseEventArgs e)
    {
        HitTestResult hit = chart.HitTest(e.X, e.Y, ChartElementType.AxisLabels);
        if (hit != null && hit.ChartElementType == ChartElementType.AxisLabels)
        {
            Axis ax = chart.ChartAreas[0].AxisX;
            var lab = hit.Object as CustomLabel;
            if (lab == null || lab.Axis == ax) return;
            double d = (lab.ToPosition + lab.FromPosition) / 2d;
            DateTime dt = DateTime.FromOADate(d);
            string tip =  dt.ToString(ax.LabelStyle.Format);
            ax.ToolTip = tip; 
        }
    }

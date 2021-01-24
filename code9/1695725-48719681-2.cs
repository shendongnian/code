    chart1.ChartAreas[0].RecalculateAxesScale();
    foreach (DateTime d in markers)
    {
        VerticalLineAnnotation va = new VerticalLineAnnotation();
        va.AxisX = chart1.ChartAreas[0].AxisX;
        va.AxisY = chart1.ChartAreas[0].AxisY;
        va.X = d.ToOADate();
        va.ClipToChartArea = chart1.ChartAreas[0].Name;
        va.IsInfinitive = true;
        va.LineColor = Color.Red;
        va.Width = 1;
        chart1.Annotations.Add(va);
    }

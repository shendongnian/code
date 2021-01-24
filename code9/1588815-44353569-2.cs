    AddPoints();
    ChartArea ca = chart1.ChartAreas[0];
    ca.AxisX.Minimum = 0;  // optional
    ca.AxisX.MajorGrid.Enabled = false;
    ca.AxisX.MajorTickMark.Enabled = false;
    ca.AxisX.LabelStyle.Enabled = false;
    stops.AddRange(new[] { 0, 15, 45, 50.5, 65, 90, 100 });

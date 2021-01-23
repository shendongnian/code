    ChartArea ca = chart.ChartAreas[0];
    chart.Legends.Clear();
    chart.BackColor = Color.DarkSlateGray;
    ca.BackColor = Color.LightSteelBlue;
    ca.Position = new ElementPosition(2, 5, 93, 75);  // make room
    ca.Area3DStyle.Enable3D = true;
    ca.Area3DStyle.PointDepth = 25;
    ca.Area3DStyle.WallWidth = 0;
    ca.AxisX.MajorGrid.Enabled = false;
    ca.AxisY.MajorGrid.LineColor = Color.White;
    ca.AxisY.LineColor = Color.White;
    ca.AxisY.LabelStyle.ForeColor = Color.White;
    ca.AxisX.LabelStyle.Enabled = false;
    ca.AxisX.LineColor = Color.White;
    ca.AxisX.MajorTickMark.Enabled = false;

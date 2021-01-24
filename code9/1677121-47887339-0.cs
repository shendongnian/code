    ttt.Points.AddXY(0, 10);
    ttt.Points.AddXY(10, 0);
    ttt.Points.AddXY(0, -10);
    ttt.Points.AddXY(-10, 0);
    ttt.Points.AddXY(0, 10);
    this.chart1.Series.Add(ttt);
    chart1.ChartAreas[0].AxisX.Crossing = 0; // <--- These two lines
    chart1.ChartAreas[0].AxisY.Crossing = 0;

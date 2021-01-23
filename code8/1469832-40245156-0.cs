    void prepare3dChart(Chart chart, ChartArea ca)
    {
        ca.Area3DStyle.Enable3D = true;  // set the chartarea to 3D!
        ca.AxisX.Minimum = -250;
        ca.AxisY.Minimum = -250;
        ca.AxisX.Maximum = 250;
        ca.AxisY.Maximum = 250;
        ca.AxisX.Interval = 50;
        ca.AxisY.Interval = 50;
        ca.AxisX.Title = "X-Achse";
        ca.AxisY.Title = "Y-Achse";
        ca.AxisX.MajorGrid.Interval = 250;
        ca.AxisY.MajorGrid.Interval = 250;
        ca.AxisX.MinorGrid.Enabled = true;
        ca.AxisY.MinorGrid.Enabled = true;
        ca.AxisX.MinorGrid.Interval = 50;
        ca.AxisY.MinorGrid.Interval = 50;
        ca.AxisX.MinorGrid.LineColor = Color.LightSlateGray;
        ca.AxisY.MinorGrid.LineColor = Color.LightSlateGray;
        // we add two series:
        chart.Series.Clear();
        for (int i = 0; i < 2; i++)
        {
            Series s = chart.Series.Add("S" + i.ToString("00"));
            s.ChartType = SeriesChartType.Bubble;   // this ChartType has a YValue array
            s.MarkerStyle = MarkerStyle.Circle;
            s["PixelPointWidth"] = "100";
            s["PixelPointGapDepth"] = "1";
        }
        chart.ApplyPaletteColors();
        // add a few test data..
        Random rnd = new Random(9);
        for (int i = 0; i < 100; i++)
        {
            double x = Math.Cos(i/10f )*88 + rnd.Next(5);
            double y = Math.Sin(i/11f)*88 + rnd.Next(5);
            double z = Math.Sqrt(i*2f)*88 + rnd.Next(5);
            AddXY3d( chart.Series[0], x, y, z);
            AddXY3d( chart.Series[1], x-111, y-222, z);
        }
    }

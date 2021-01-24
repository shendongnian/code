    private void testChartRect()
    {
      for (int i = 0; i < 4; i++)
      {
        Line line = new Line(tChart1.Chart);
        tChart1.Series.Add(line);
        line.Chart = tChart1.Chart;
        line.FillSampleValues();
        Axis axis = new Axis();
        tChart1.Axes.Custom.Add(axis);
        line.CustomVertAxis = axis;
        axis.StartPosition = i * 100 / 4;
        axis.EndPosition = (i + 1) * 100 / 4;
        axis.AxisPen.Color = line.Color;
        axis.Labels.Font.Color = line.Color;
      }
      
      tChart1.Aspect.View3D = false;
      tChart1.Panel.MarginLeft = 10;
      tChart1.AfterDraw += TChart1_AfterDraw1;
    }
    private void TChart1_AfterDraw1(object sender, Graphics3D g)
    {
      tChart1.Graphics3D.Brush.Color = Color.Red;
      tChart1.Graphics3D.Brush.Transparency = 80;
      tChart1.Graphics3D.Rectangle(tChart1.Chart.ChartRect);
    }

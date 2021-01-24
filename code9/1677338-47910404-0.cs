    chart.PostPaint += (sender, args) =>
    {
        for (var j = 0; j < 2; j++)
        {
            for (var i = 0; i < args.Chart.Series[j].Points.Count; i++)
            {
                var point = args.Chart.Series[j].Points[i];
                var altPoint = args.Chart.Series[j == 0 ? 1 : 0].Points[i];
                var above = point.YValues[0] > altPoint.YValues[0] || (point.YValues[0] == altPoint.YValues[0] && j == 0);
                var pos = PointF.Empty;
                pos.X =
                    (float)
                    args.ChartGraphics.GetPositionFromAxis("ChartArea1", AxisName.X,
                        point.XValue);
                pos.Y =
                    (float)
                    args.ChartGraphics.GetPositionFromAxis("ChartArea1", AxisName.Y,
                        point.YValues[0]);
                
                pos = args.ChartGraphics.GetAbsolutePoint(pos);
                pos.Y += (above ? - 20 : 10);
                pos.X += -10;
                args.ChartGraphics.Graphics.DrawString($"{values[j][i]}%",
                    new Font(FontFamily.GenericSansSerif, 10),
                    new SolidBrush(_colorPallette[j]), pos);
            }
        }
    };

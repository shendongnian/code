    byte[] GetChartImage(params int[] points)
    {
        using (var stream = new MemoryStream())
        {
            using (var chart = new Chart())
            {
                chart.ChartAreas.Add(new ChartArea());
                Series s = new Series();
                for (int i = 0; i < points.Length; ++i)
                {
                    s.Points.AddXY(points[i], points[i]);
                }
                chart.Series.Add(s);
                chart.SaveImage(stream, ChartImageFormat.Png);
            }
            return stream.ToArray();
        }
    }

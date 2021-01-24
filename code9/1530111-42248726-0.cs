    Random rnd = new Random(0);
    List<Color> colors = new List<Color>() { Color.Red, Color.Firebrick, Color.Gold,
        Color.DeepPink, Color.Azure, Color.IndianRed, Color.ForestGreen };
    ChartArea ca = chart.ChartAreas[0];
    Series s = chart.Series[0];
    for (int i = 1; i < 7; i++)
    {
        s.Points.AddXY(i, i+ rnd.Next(20 - i));
    }

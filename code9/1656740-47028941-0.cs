    Color[] colors = new Color[] { Color.Green, Color.LightGreen, Color.YellowGreen, Color.Yellow, Color.Maroon, Color.Red };
    foreach (Series series in Chart2.Series)
      {
        foreach (DataPoint point in series.Points)
         {
           //point.LabelBackColor = colors[series.Points.IndexOf(point)];
           point.Color = colors[series.Points.IndexOf(point)];
         }
      }
    

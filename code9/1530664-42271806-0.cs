    Series s = chart.Series[0];
    // string[] vec = new string[7] 
    // { "11:00", "12:00", "1:00", "2:00", "3:00", "4:00", "5:00" };
    TimeSpan[] tvec = new TimeSpan[7] 
              { new TimeSpan( 11, 0, 0), new TimeSpan( 12, 0, 0), new TimeSpan( 13, 0, 0),
                new TimeSpan( 14, 0, 0) ,new TimeSpan( 15, 0, 0) ,new TimeSpan( 16, 0, 0),
                new TimeSpan( 17, 0, 0)  };
    DateTime d0 = new DateTime(0);
    foreach (var t in tvec)
        s.Points.AddXY(d0.Add(t), t.Hours);
    ChartArea ca = chart.ChartAreas[0];
    s.XValueType = ChartValueType.DateTime;
    ca.AxisX.LabelStyle.Format = "h:mm";
    ca.AxisX.Minimum = d0.Add(tvec.First()).ToOADate();
    ca.AxisX.Maximum = d0.Add(tvec.Last()).ToOADate();

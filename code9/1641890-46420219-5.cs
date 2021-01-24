    // create an odered list of data:
    List<double> data = new List<double>();
    for (int i = 0; i < 12; i++) data.Add(rnd.Next(100) * rnd.Next(i * 5));
    data = data.OrderByDescending(x => x).ToList();
    // now add with dummy x and y-values:
    Series s = chart1.Series[0];
    for (int i = 0; i < data.Count; i++)
    {
        int p = s.Points.AddXY(i, data.Count - i);   // dummy values
        DataPoint dp = s.Points[p];
        dp.Label = data[i] +"";        // real value, formatted
        dp.Tag= data[i] +"";           // real value
    }

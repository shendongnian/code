    void SetColors(Series candles, Series columns)
    {
        for (int i = 0; i < candles.Points.Count; i++)
        {
            DataPoint dp = candles.Points[i];
            columns.Points[i].Color =
                dp.YValues[2] > dp.YValues[3] ? Color.Red :  Color.Green;
        }
    }

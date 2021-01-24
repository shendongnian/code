    Setup24HoursAxis(chart1, DateTime.Today);
    TrainStops = SetupTrainStops(17);
    SetupTrainStopAxis(chart1);
    for (int i = 0; i < 23 * 3; i++)
    {
        AddTrainStopSeries(chart1, DateTime.Today.Date.AddMinutes(i * 20),
                           17 - rnd.Next(4), i% 5 == 0 ? 1 : 0);
    }
    // this exports the image above:
    chart1.SaveImage("D:\\trains.png", ChartImageFormat.Png);

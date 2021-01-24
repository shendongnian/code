    chart1.Series.Clear();
    var IncSeries = new Series("Income");
    var ExpSeries = new Series("Expense");
    IncSeries.Points.DataBindXY(new[] { "Today's Income" }, new[] { Income });
                ExpSeries.Points.DataBindXY(new[] { "Today's Expense" }, new[] { Expense });
    chart1.ChartAreas[0].AxisX.IsReversed = true;
    chart1.Series.Add(IncSeries);
    chart1.Series.Add(ExpSeries);
    chart1.Series[0].IsVisibleInLegend = false;

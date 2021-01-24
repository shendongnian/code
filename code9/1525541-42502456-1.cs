    private void LoadChartContents()
    {
        List<Report> lstSource = new List<Report>();
        for (int i = 1; i <= 12; i++)
        {
            if (i == 2)
            {
                lstSource.Add(new Report() { months = 2, value = 10 });
            }
            if (i == 9)
            {
                lstSource.Add(new Report() { months = 9, value = 15 });
            }
            else
            {
                lstSource.Add(new Report() { months = i, value = 0 });
            }
        }
        (Chart.Series[0] as ColumnSeries).ItemsSource = lstSource;
        //lstSource.Add(new Report() { months = 2, value = 10 });
        //lstSource.Add(new Report() { months = 9, value = 15 }); 
        //(Chart.Series[0] as ColumnSeries).IndependentAxis = new LinearAxis { Minimum = 1, Maximum = 12, Orientation = AxisOrientation.X, Interval = 1 };
    }

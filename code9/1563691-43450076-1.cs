    public static void Setup24HoursAxis(Chart chart, DateTime dt)
    {
        chart.Legends[0].Enabled = false;
        Axis ax = chart.ChartAreas[0].AxisX;
        ax.IntervalType = DateTimeIntervalType.Hours;
        ax.Interval = 1;
        ax.Minimum =  dt.ToOADate();
        ax.Maximum = (dt.AddHours(24)).ToOADate();
        ax.LabelStyle.Format = "H:mm";
        }

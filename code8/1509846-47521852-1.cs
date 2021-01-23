    public SimplePieControl()
    {
        InitializeComponent();
        myPieChart.Series.Add(new PieSeries { Title = "BAD", Fill = Brushes.Red, StrokeThickness=0, Values = new ChartValues<double> { 0.0 } });
        myPieChart.Series.Add(new PieSeries { Title = "GOOD", Fill = Brushes.Green, StrokeThickness=0, Values = new ChartValues<double> { 100.0 } });
        DataContext = this;
    }

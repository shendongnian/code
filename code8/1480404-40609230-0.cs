    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // Just add the following line.
        Chart.DataContext = DataContext;
        Chart.StrokeThickness = 3;
        Chart.SetBinding(LineChart.ItemsSourceProperty, new Binding("ExampleCollection"));
        // ...
    }

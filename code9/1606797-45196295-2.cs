    private void SimulateClick(object sender, RoutedEventArgs e)
    {
        (sender as Button).Content = new TextBlock { Text = (e as TransferEventArgs)?.Param?.ToString() };
    }
    private void SimulateClick3(object sender, RoutedEventArgs e)
    {
        SimulateClick(sender, e);
        (sender as Button).IsEnabled = !(sender as Button).IsEnabled; //toggle button
    }
    private void InvokeEventOnVM(object sender, RoutedEventArgs e)
    {
        var vm = new ViewModelBase();
        this.DataContext = vm;
        vm.TransferClick();
    }

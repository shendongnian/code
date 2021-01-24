    private void SimulateClick1(object sender, RoutedEventArgs e)
    {
        (sender as Button).Content = new TextBlock { Text = (e as InvokeEventArgs)?.Param?.ToString() };
    }
    private void SimulateClick2(object sender, RoutedEventArgs e)
    {
        SimulateClick1(sender, e);
        (sender as Button).IsEnabled = !(sender as Button).IsEnabled; //toggle button
    }
    private void InvokeEventOnVM(object sender, RoutedEventArgs e)
    {
        var vm = new ViewModelBase();
        this.DataContext = vm;
        vm.TransferClick1();
        vm.TransferClick2();
    }

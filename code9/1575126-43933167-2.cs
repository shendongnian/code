    protected override void OnClosed(EventArgs e)
    {
        var vm = this.DataContext as MainWindowViewModel;
        vm.SerialPort.Disconnect();
        base.OnClosed(e);
    }

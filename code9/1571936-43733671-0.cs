    testCommand = new RelayCommand(ExecuteTest);
    private void ExecuteTest(object parameter)
        {
            System.Windows.Controls.DataGrid grid = parameter as System.Windows.Controls.DataGrid;
            grid.IsEnabled = true/false;
        }

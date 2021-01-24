    private void dataGridReports_Loaded(object sender, RoutedEventArgs e)
    {
        DataGridFill();
    }
    private async void DataGridFill()
    {
        DataGridBusyIndicator.IsBusy = true;
        try
        {
            var items = await Task.Run(() =>
            {
                var manager = new ReportMadeManager();
                if (Convert.ToInt32(statusReportID.Content) == 4)
                {
                    return manager.selectReportDJVJ(
                        Convert.ToInt32(statusParameter1.Content),
                        Convert.ToInt32(statusParameter2.Content));
                }
                else if (Convert.ToInt32(statusReportID.Content) == 5)
                {
                    return manager.selectReportCriticalProducts(
                        Convert.ToInt32(statusParameter1.Content),
                        Convert.ToInt32(statusParameter2.Content));
                }
            });
            dataGridReports.ItemsSource = items;
        }
        finally
        {
            DataGridBusyIndicator.IsBusy = false;
        }
    }

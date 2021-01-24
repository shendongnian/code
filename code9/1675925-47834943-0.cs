    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        viewModel.IsWorking = true;
        await Task.Run(() =>
        {
           // do some long processing
        });
        viewModel.IsWorking = false;
    }

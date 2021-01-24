    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        var viewModel = new AllAllergiesViewModel();
        grdData.DataContext = viewModel;
        await viewModel.GetAllAllergies();
    }

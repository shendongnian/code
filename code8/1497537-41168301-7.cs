    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        var viewModel = new PicturesViewModel();
        DataContext = viewModel;
        await viewModel.GetImages();
    }

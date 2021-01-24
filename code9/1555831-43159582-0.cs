    private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
        var setImageTasks = this.imageViewModels.Select(async imageViewModel => {
            var randomAccessStream = await SlowImageSourceProvider.GetRandomAccessStream(imageViewModel.Id);
            await imageViewModel.ImageSource.SetSourceAsync(randomAccessStream);
        }).ToArray();
        await Task.WhenAll(setImageTasks);
    }

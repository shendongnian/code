    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var vm = (ViewModel)DataContext;
        foreach (var file in Directory.EnumerateFiles(...))
        {
            vm.Photos.Add(new Photo { FileName = file });
        }
        foreach (var photo in vm.Photos)
        {
            await photo.Load();
        }
    }

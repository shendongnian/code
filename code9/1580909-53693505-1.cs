    private void VideosLibraryGridView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args
    {
        args.RegisterUpdateCallback(LoadImage);
    }
    private async void LoadImage(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        var templateRoot = args.ItemContainer.ContentTemplateRoot as Grid;
        var imageurl = (args.Item as model).ThumbnailUri;
        var cache = await getimagefromfileasync(imageurl);
        //check your image location based on your template first.
        var image = templateRoot.Children[0] as Image; 
        image.Source = new BitmapImage()
        {
            UriSource = new Uri(cache.Path)
        };
        image.Opacity = 1;
    }

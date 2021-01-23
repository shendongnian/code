    public class ImageItem
    {
        public ImageSource Image { get; set; }
        public string ImageText { get; set; }
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var imageCollection = new ObservableCollection<ImageItem>();
        AdaptiveGV.ItemsSource = imageCollection;
        for ...
        {
            ...
            await bitmapimage.SetSourceAsync(stream); 
            ...
            imageCollection.Add(new ImageItem()
            {
                Image = bitmapimage,
                ImageText = filesList[i].Name
            });
        }
    }

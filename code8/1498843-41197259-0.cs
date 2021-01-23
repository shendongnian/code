    public class ImageItem
    {
        public ImageSource Image { get; set; }
        public string ImageText { get; set; }
    }
    ...
    var imageCollection= new ObservableCollection<ImageItem>();
    AdaptiveGV.ItemsSource = imageCollection;
    for (...)
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

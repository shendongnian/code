    public sealed partial class NavigationMenuButtonTemplate : UserControl
    {
        public NavigationMenuButtonTemplate()
        {
            this.InitializeComponent();
        }
        private void NavigationMenuIconImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var image = (Image)sender;
            var bitmapImage = image.Source as BitmapImage;
            var uri = bitmapImage?.UriSource;
            var uriPath = uri?.AbsolutePath;
            var newUriPath = $@"ms-appx://{uriPath.Replace("White", "Black")}";
            image.Source = new BitmapImage(new Uri(newUriPath, UriKind.RelativeOrAbsolute));
        }
    }

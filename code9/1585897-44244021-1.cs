    public partial class ImageWindow : Window
    {
        public ImageWindow(string fileName)
        {
            InitializeComponent();
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(fileName);
            image.EndInit();
            image.Freeze();
            image_Image.Source = image; //Set Image controls image source to BitmapImage
        }
    }

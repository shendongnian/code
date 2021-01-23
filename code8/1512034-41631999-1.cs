    public class ImageItem
    {
        public string ImagePath { get; set; }
        private BitmapImage image;
        public BitmapImage Image
        {
            get
            {
                if (image != null)
                {
                    image = new BitmapImage();
                    image.ImageFailed += (s, e) =>
                        image.UriSource = new Uri("ms-appx:///Images/default.png");
                    image.UriSource = new Uri(ImagePath);
                }
                return image;
            }
        }
    }

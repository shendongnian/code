    public class MyViewModel
    {
        public void LoadImage()
        {
            ImageSource = new BitmapImage(new Uri("assets/images/yourImage.jpg", UriKind.Relative));
        }
        public ImageSource ImageSource { get; set; }
    }

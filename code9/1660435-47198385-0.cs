    public class DataStuff
    {
        public ImageSource ImageFilename { get; set; }
        public DataStuff(string imageFilename)
        {
            ImageFilename = new BitmapImage(new Uri(imageFilename, UriKind.Absolute));
        }
    }

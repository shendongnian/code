    public class MainWindowViewModel
    {
        public void LoadImages()
        {
            var d = new DirectoryInfo("assets/images");
            var images = d.GetFiles();
            MyImages = images.Select(x => new MyImageModel(x.Name, new BitmapImage(new Uri(x.FullName))));
        }
        public IEnumerable<MyImageModel> MyImages { get; set; }
    }

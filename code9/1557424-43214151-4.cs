    public class MyImageModel
    {
        public MyImageModel(string name, ImageSource imageSource)
        {
            Name = name;
            ImageSource = imageSource;
        }
        public string Name { get; set; }
        public ImageSource ImageSource { get; set; }
    }

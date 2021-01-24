    public class UC1 : UserControl
    {
        UC5 UserControl5 = new UC5();
        PictureBox picturebox;
        
        public UC1()
        {
            picturebox = new PictureBox();
            UserControl5.ImageChanged += UserControl5_ImageChanged;
        }
        private void UserControl5_ImageChanged(Image newImage)
        {
            if (this.picturebox.Image != null)
                this.picturebox.Image.Dispose();
            this.picturebox.Image = (Image)newImage.Clone();
        }
    }
    public class UC5 : UserControl
    {
        public delegate void ImageChangedHandler(Image newImage);
        public Image image {
            get { return _image; }
            set {
                if (_image != value) {
                    _image = value;
                    ImageChanged?.Invoke(_image);
                } } }
        public Image _image = null;
        public event ImageChangedHandler ImageChanged;
    }

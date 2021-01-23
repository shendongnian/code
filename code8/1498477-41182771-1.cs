    public class MainScreenView : View
    {
        private ImageView portraitImageView;
        private ImageView landscapeImageView;
        public MainScreenView(ImageView portrait, ImageView landscape)
            :base(portrait, landscape)
        {
           portraitImageView = portrait;
           landscapeImageView = landscape;
        }
        protected override void OnInitialize() { }
        public ImageView GetPortrait() { return portraitImageView; }
        public ImageView GetLandscape() { return landscapeImageView; }
    }
    public class ImageView : View
    {
        private Image image;
        public ImageView(Image image)
            :base(image)
        { 
            this.image = image; 
        }
        protected override void OnInitialize() { image.Show(); }
        public Image GetImage() { return image; }
    }
   

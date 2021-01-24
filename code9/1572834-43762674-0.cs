    public class SerializableBrush
    {
        public virtual Brush ToBrush()
        {
            return null;
        }
    }
    public class SerializableColorBrush : SerializableBrush
    {
        public Color Color{ get; set; }
        public SerializableColorBrush(SolidColorBrush Brush)
        {
            this.Color = Brush.Color;
        }
        public override Brush ToBrush()
        {
            SolidColorBrush brush = new SolidColorBrush(this.Color);
            return brush;
        }
    }
    public class SerializableImageBrush : SerializableBrush
    {
        public ImageSource ImageSource { get; set; }
        public TileMode TileMode { get; set; }
        public Stretch Stretch { get; set; }
        public AlignmentX AlignmentX { get; set; }
        public AlignmentY AlignmentY { get; set; }
        public SerializableImageBrush(ImageBrush Brush)
        {
            this.ImageSource = Brush.ImageSource;
            this.TileMode = Brush.TileMode;
            this.Stretch = Brush.Stretch;
            this.AlignmentX = Brush.AlignmentX;
            this.AlignmentY = Brush.AlignmentY;
        }
        public override Brush ToBrush()
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = ImageSource;
            brush.TileMode = TileMode;
            brush.Stretch = Stretch;
            brush.AlignmentX = AlignmentX;
            brush.AlignmentY = AlignmentY;
            return brush;
        }
    }

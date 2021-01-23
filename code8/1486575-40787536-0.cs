    public class GifImage
    {
        private Image gifImage;
        private FrameDimension dimension;
        private int frameCount;
        private int currentFrame = -1;
        private bool reverse;
        private int step = 1;
    
        public GifImage(string path)
        {
            gifImage = Image.FromFile(path);
            dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
            frameCount = gifImage.GetFrameCount(dimension);
        }
    
        public bool ReverseAtEnd {
            get { return reverse; }
            set { reverse = value; }
        }
    
        public Image GetNextFrame()
        {
    
            currentFrame += step;
            if (currentFrame >= frameCount || currentFrame < 1) {
                if (reverse) {
                    step *= -1;
                    currentFrame += step;
                }
                else {
                    currentFrame = 0;
                }
            }
            return GetFrame(currentFrame);
        }
    
        public Image GetFrame(int index)
        {
            gifImage.SelectActiveFrame(dimension, index);
            return (Image)gifImage.Clone();
        }
    }
    

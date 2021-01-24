    public abstract class ImageTransition
    {
        protected int imageId { get; set; }
        public Dictionary<int, Image> ImageDictionary { get; set; }
        protected abstract void TransitionToNextImageId();
        public Image GetNextImage()
        {
            TransitionToNextImageId();
            return ImageDictionary[imageId];
        }
    }

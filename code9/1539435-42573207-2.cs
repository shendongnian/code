    public class Model
    {
        public int InitialIndex { get; set; }
        public int ImageCount { get { return ImageList.Count; } }
        public List<string> ImageList { get; set; }
    }

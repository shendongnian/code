    public class Video
    {
        public string Name { get; set; }
        public string VideoMethod()
        {
            return string.Format(" Clicked {0}", Name);
        }
    }

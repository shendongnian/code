    internal class Sound
    {
        public string Name { get; set; }
        public string AudioFile { get; set; }
        public BitmapImage WhiteImage { get; set; }
        public BitmapImage BlackImage { get; set; }
        public KeyColor Color { get; set; }
    
        public Sound(string name, KeyColor color)
        {
            Name = name;
            Color = color;
    
            if (color == KeyColor.Black)
            {
                BlackImage = new BitmapImage(new Uri("ms-appx:///Assets/Images/Black.png"));
                AudioFile = string.Format("ms-appx:///Assets/Audio/22.wav", name);
            }
            else if (color == KeyColor.White)
            {
                WhiteImage = new BitmapImage(new Uri("ms-appx:///Assets/Images/White.PNG"));
                AudioFile = string.Format("ms-appx:///Assets/Audio/11.wav", name);
            }
        }
    }
    
    public enum KeyColor
    {
        Black,
        White
    }

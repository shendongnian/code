    class ImageWithText
    {
        public Image Image { get; set; }
        public string Text { get; set; }
        public ImageWithText(Image image, string text)
        {
            Image = image;
            Text = text;
        }
    }

    class TextDocument
    {
        public TextFormats TheFormat { get; set; }
        public enum TextFormats 
        {
            Word, Pdf, ...
        }
    }
    class ImageDocument
    {
        public ImageFormats TheFormat { get; set; }
        public enum ImageFormats
        {
            JPEG, TIF, BMP, ...
        }
    }

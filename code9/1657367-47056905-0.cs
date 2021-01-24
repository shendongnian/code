    class TextDocument
    {
        TextFormats TheFormat { get; set; }
        enum TextFormats 
        {
            Word, Pdf, ...
        }
    }
    class ImageDocument
    {
        ImageFormats TheFormat { get; set; }
        enum ImageFormats
        {
            JPEG, TIF, BMP, ...
        }
    }

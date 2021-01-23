    public interface IPdfConvertible
    {
        public string GetText()
    }
    // same for FileRequest...
    public class BoxRequest : IPdfConvertible
    {
        // ...
        public string GetText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name);
            sb.AppendLine(this.Department);
            sb.AppendLine(this.Location.LocationName);
            return sb.ToString();
        }
    }
    public class PdfBuilder
    {
        private readonly IPdfConvertible request;
        public PdfBuilder(IPdfConvertible request)
        {
            this.request = request;
        }
        public PdfDocument BuildPdfDocument()
        {
            // ...
            tf.DrawString(request.GetText(), font, XBrushes.Black, rect);          
            // ...
        }
    }

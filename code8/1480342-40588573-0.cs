    public class BoxRequest
    {
        // ...
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(_boxRequest.Name);
            sb.AppendLine(_boxRequest.Department);
            sb.AppendLine(_boxRequest.Location.LocationName);
            return sb.ToString();
        }
    }
    public class PdfBuilder
    {
        private readonly object request;
        public PdfBuilder(object request)
        {
            this.request = request;
        }
        public PdfDocument BuildPdfDocument()
        {
            // ...
            tf.DrawString(request.ToString(), font, XBrushes.Black, rect);          
            // ...
        }
    }

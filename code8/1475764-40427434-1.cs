    public class PdfCopy : PdfWriter
    {
        // ...
   
        public PdfCopy(Document document, Stream os) : base(new PdfDocument(), os)     {
            // ...
        }
 
        // ...
    }

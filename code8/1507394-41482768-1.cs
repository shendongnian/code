    public class MyPdfPageEvent : iTextSharp.text.pdf.PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            writer.AddPageDictEntry(PdfName.ROTATE, PdfPage.SEASCAPE);
        }
    }

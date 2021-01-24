    public class PdfEventHelper : PdfPageEventHelper
    {
        public PdfEventHelper()
        {
            
        }
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
        }
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            if (writer.PageNumber == 1)
            {
                //replace this table with the table that you want to write on the first page
                PdfPTable pdfTable = new PdfPTable(new[] { 1f, 1f, 1f, 1f });
                pdfTable.WriteSelectedRows(0, -1, 10, pdfTable.TotalHeight + 10, writer.DirectContent);
                base.OnEndPage(writer, document);
            }
            
        }
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }

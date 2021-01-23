    public class PageEventHeader : PdfPageEventHelper
    {
        public string HeaderText { get; set; }
    
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            float cellHeight = document.TopMargin;
            Rectangle page = document.PageSize;
            PdfPTable table = new PdfPTable(1) { TotalWidth = page.Width };
            table.AddCell(new PdfPCell(new Phrase(HeaderText)) 
            { 
                Border = PdfPCell.NO_BORDER,
                FixedHeight = cellHeight,
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.WriteSelectedRows(
                0, -1, 0,
                page.Height - cellHeight + table.TotalHeight,
                writer.DirectContent
            );
        }
    }

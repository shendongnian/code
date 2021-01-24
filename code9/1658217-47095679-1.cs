    #region Footer Class
    
        public partial class Footer : PdfPageEventHelper
        {
            #region Constructor
            public Footer()
            {
                
            }
            #endregion
    
            #region OnStartPage
            public override void OnStartPage(PdfWriter writer, Document document)
            {
                if (document.PageNumber > 1)
                {
                    string footerMessage = "Page " + document.PageNumber;
                    Paragraph footer = new Paragraph(footerMessage, FontFactory.GetFont(FontFactory.HELVETICA, 9));
                    footer.Alignment = Element.ALIGN_RIGHT;
                    PdfPTable footerTbl = new PdfPTable(numColumns: 1);
                    footerTbl.WidthPercentage = 100;
                    footerTbl.TotalWidth = PageSize.A4.Width;
    
                    PdfPCell cell = new PdfPCell(new Phrase(footer));
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    footerTbl.AddCell(cell);
                    footerTbl.WriteSelectedRows(0, -1, document.RightMargin - 80, document.Top + 30, writer.DirectContent);
                }
            }
            #endregion
    
            #region OnEndPage
            public override void OnEndPage(PdfWriter writer, Document doc)
            {
    
                string footerMessage = "Footer Text";
                
                
                    Paragraph footer = new Paragraph(footerMessage, FontFactory.GetFont(FontFactory.HELVETICA, 9));
                    footer.Alignment = Element.ALIGN_CENTER;
                    PdfPTable footerTbl = new PdfPTable(numColumns: 1);
                    footerTbl.TotalWidth = PageSize.A4.Width;
    
                    PdfPCell cell = new PdfPCell(new Phrase(footer));
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    footerTbl.AddCell(cell);
                    //footerTbl.WriteSelectedRows(0, 10, 50, 55, writer.DirectContent);
                    footerTbl.WriteSelectedRows(0, -1, 0, 55, writer.DirectContent);
    
            }
            #endregion
    
        }
    
        #endregion

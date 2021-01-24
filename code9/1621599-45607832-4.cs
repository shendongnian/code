    Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment; filename=abc.pdf");
                Response.Charset = "";            
                Response.BinaryWrite(getbinary());
                Response.End();  
    
      public byte[] getbinary()
            {
                Document pdfReport = null;
                pdfReport = new Document(PageSize.A4, 25, 25, 40, 25);
                MemoryStream msReport = new MemoryStream();
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfReport, msReport);
    
                pdfReport.Open();
    
                if (!string.IsNullOrEmpty("Header Text"))
                {
                    Header objHeaderFooter = new Header();
                    objHeaderFooter.SetHeader(new Phrase("Header Text"));
                    pdfWriter.PageEvent = objHeaderFooter;
                }
    
                PdfPTable ptData1 = new PdfPTable(1);
                ptData1.SpacingBefore = 8;
                ptData1.DefaultCell.Padding = 1;
                ptData1.WidthPercentage = 100;
                ptData1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                ptData1.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
    
                PdfPCell cell1 = new PdfPCell();
                cell1.BorderWidth = 0.001F;
                cell1.BackgroundColor = new BaseColor(250, 250, 250);
                cell1.BorderColor = new BaseColor(100, 100, 100);
                cell1.Phrase = new Phrase("Sample text");
                ptData1.AddCell(cell1);
    
    
                PdfPCell cell = new PdfPCell();
                cell.BorderWidth = 0.001F;
                cell.BackgroundColor = new BaseColor(200, 200, 200);
                cell.BorderColor = new BaseColor(100, 100, 100);
    
                cell.Phrase = new Phrase("test value");
                ptData1.AddCell(cell);
                pdfReport.Add(ptData1);
    
                pdfReport.Close();
                return  msReport.ToArray();
                
            }
    
    public class Header : PdfPageEventHelper
        {
            protected Phrase header;
    
            public void SetHeader(Phrase header)
            {
                this.header = header;
            }
    
            public void onEndPage(PdfWriter writer, Document document)
            {
                PdfContentByte canvas = writer.DirectContent;
                ColumnText.ShowTextAligned(canvas, Element.ALIGN_RIGHT, header, 559, 806, 0);
            }
        }

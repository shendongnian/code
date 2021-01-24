    using iTextSharp.text;
    using iTextSharp.text.pdf;
    string shippingaddress = "My name is khan <br/>";
    shippingaddress += "And I am not a terrorist<br/>";
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {            
                //Below code defines the PDF generate Size
                Rectangle newRect = new Rectangle(0, 0, 240, Convert.ToSingle(138.6));
                Document document = new Document(newRect,10f,10f,10f,10f);
                Document.Compress = true;
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                Font boldFont = new Font(Font.FontFamily.HELVETICA, 12,Font.BOLD);
                Paragraph para = new Paragraph("Header", boldFont);
                document.Add(para);
                string text = shippingaddress.Replace("<br/>", "\n");
                Paragraph paragraph = new Paragraph();
                paragraph.SpacingBefore = 2;
                paragraph.SpacingAfter = 2;
                paragraph.Leading = 12;
                paragraph.Alignment = Element.ALIGN_LEFT;
                paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f,BaseColor.BLACK);
                paragraph.Add(text);
                document.Add(paragraph);
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                string pdfName = "Movie Name";
                Response.AddHeader("Content-Disposition", "inline; filename=" + pdfName + ".pdf");    
                Response.ContentType = "application/pdf";
                Response.Buffer = true;   
                Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();    
            }

    string filenm = "test";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 70, 40, 70, 40);
            var fpath = Server.MapPath("~/PDFFiles/FunctionProspectus/");
            PdfWriter.GetInstance(doc, new FileStream(fpath + filenm, FileMode.Create));
            Font fontH1 = new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD);
            doc.Open();
            doc.NewPage();
            Paragraph Heading = new Paragraph("Test");
            Heading.Alignment = Element.ALIGN_CENTER;
            doc.Add(Heading);
            
            doc.Add(Chunk.NEWLINE);               
            
            doc.Close();
            
            string contentType = "application/pdf";
            return File(Server.MapPath("~/PDFFiles/FunctionProspectus/") + filenm, contentType);

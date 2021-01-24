          private Font _largeFont = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD, BaseColor.BLACK); 
          void generatepdffile(string content)
              {
                Document doc = new Document();
                doc.Open(); 
                AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, new Chunk(content));
                doc.Close();
                PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("file1.pdf"), FileMode.Create));
              }

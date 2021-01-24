          private Font _largeFont = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD, BaseColor.BLACK); 
          void generatepdffile(string content)
              {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("file1.pdf"), FileMode.Create));
                doc.Open(); 
                AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, new Chunk(content));
                doc.Close();
              }

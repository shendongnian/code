            [Route("GerarPdf")]
            [HttpGet()]
            public object GerarPdf()
            {
    
                var doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                var mem = new MemoryStream();
    
                PdfWriter wri = PdfWriter.GetInstance(doc, mem);
    
                doc.Open();//Open Document to write
                Paragraph paragraph = new Paragraph("This is my first line using Paragraph.");
                Phrase pharse = new Phrase("This is my second line using Pharse.");
                Chunk chunk = new Chunk(" This is my third line using Chunk.");
    
                doc.Add(paragraph);
                doc.Add(pharse);
                doc.Add(chunk);
    
                doc.Close();
    
                var pdf = mem.ToArray();
    
                return Convert.ToBase64String(pdf);
            }

    [Route("GerarPdf")]
    [HttpGet()]
    public object GerarPdf()
    {
        byte[] pdf = new byte[] { };
        using (var mem = new MemoryStream())
        {
            using (var doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35))
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, mem);
                doc.Open(); //Open Document to write
                Paragraph paragraph = new Paragraph("This is my first line using Paragraph.");
                Phrase pharse = new Phrase("This is my second line using Pharse.");
                Chunk chunk = new Chunk(" This is my third line using Chunk.");
                doc.Add(paragraph);
                doc.Add(pharse);
                doc.Add(chunk);
            } // doc goes out of scope and gets closed + disposed
            pdf = mem.ToArray();
        } // mem goes out of scope and gets disposed
        return Convert.ToBase64String(pdf);
    }

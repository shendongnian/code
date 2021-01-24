    private void printPDF(object sender, EventArgs e)
    {
        string path = "D:\\Test\\" + Guid.NewGuid().ToString() + ".pdf";
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            Document docu = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(docu, fileStream);
    
            docu.Open();
    
            //Header Table
            var table = new PdfPTable(new float[] { 0.3f, 0.7f });
            table.TotalWidth = 500f;
    
            //company name
            var phrase = new Phrase("Company Name", FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.ORANGE));
            var cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            table.AddCell(cell);
    
            phrase = new Phrase("My test company", FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.ORANGE));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            table.AddCell(cell);
    
            //company address
            phrase = new Phrase("Company Address", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            table.AddCell(cell);
    
            phrase = new Phrase("123 Main Street, Your City.", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            table.AddCell(cell);
    
            docu.Add(table);
            docu.Close();
            writer.Close();
        }
    }
    private static PdfPCell PhraseCell(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = BaseColor.WHITE;
        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 2f;
        cell.PaddingTop = 0f;
        return cell;
    }

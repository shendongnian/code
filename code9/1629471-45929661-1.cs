    phrase = new Phrase();
    phrase.Add(new Chunk("Company Name\n\n", FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.ORANGE)));
    phrase.Add(new Chunk("Company Address", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
    table.AddCell(cell);
    
    //yes this is just duplicating content but proves the point
    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
    table.AddCell(cell);
    
    
    docu.Add(table);
    docu.Close();

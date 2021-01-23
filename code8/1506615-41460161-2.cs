    for (int i = 0; i < 25; i++)
    {
        var inputstring = tbText[i];
        phraseinvoice = new Phrase(inputstring,
            FontFactory.GetFont(FontFactory.TIMES_BOLD, 8)));
        PdfPCell cellbox = new PdfPCell(phraseinvoice);
        cellbox.Border = Rectangle.NO_BORDER;
        cellbox.FixedHeight = 15f;
        Invoicetable.AddCell(cellbox);
    }

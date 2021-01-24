    if (!string.IsNullOrEmpty(HeaderText))
    {
        Header objHeaderFooter = new Header();  
        objHeaderFooter.setHeader(new Phrase(HeaderText));
        pdfWriter.PageEvent = objHeaderFooter;
    }

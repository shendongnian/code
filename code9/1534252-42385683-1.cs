    PdfReader reader = new PdfReader(path);
    int pagenumber = reader.NumberOfPages;
    for (int page = 1; page <= pagenumber; page++)
    {
        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
        string tt = PdfTextExtractor.GetTextFromPage(reader, page , strategy);
        tt = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(tt)));
        File.AppendAllLines(outfile, tt, Encoding.UTF8);
    }

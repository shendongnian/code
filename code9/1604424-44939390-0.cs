	public string GetTextFromPage(string path, int pagenum)
    {
        PdfReader reader = new PdfReader(path);
        string text = PdfTextExtractor.GetTextFromPage(reader, pagenum, new LocationTextExtractionStrategy());
        reader.Close();
        return text;
    }

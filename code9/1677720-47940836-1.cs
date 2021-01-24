    public static string GetTextFromPDF(string path)
    {
        var reader = new PdfReader(path);
        var text = new StringBuilder();
        for (var i = 1; i <= reader.NumberOfPages; i++)
        {
            var data = PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy());
            text.Append(Bidi.BidiText(data, 1).Text);
        }
        return text.ToString();
    }

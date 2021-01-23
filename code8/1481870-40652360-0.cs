    public static int SetContentControlText(
        this WordprocessingDocument document,
        Dictionary<string, string> values)
    {
        if (document == null) throw new ArgumentNullException("document");
        if (values == null) throw new ArgumentNullException("values");
        int count = 0;
        foreach (SdtElement sdtElement in document.MainDocumentPart.Document.Descendants<SdtElement>())
        {
            string tag = sdtElement.SdtProperties.Descendants<Tag>().First().Val;
            if ((tag != null) && values.ContainsKey(tag))
            {
                sdtElement.Descendants<Text>().First().Text = values[tag] ?? string.Empty;
                sdtElement.Descendants<Text>().Skip(1).ToList().ForEach(t => t.Remove());
                count++;
            }
        }
        return count;
    }

    public string ReadAllTextFromWordDocFile(string fileName)
    {
        using (StreamReader streamReader = new StreamReader(fileName))
        {
            var document = new HWPFDocument(streamReader.BaseStream);
            var wordExtractor = new WordExtractor(document);
            var docText = new StringBuilder();
            foreach (string text in wordExtractor.ParagraphText)
            {
                docText.AppendLine(text.Trim());
            }
            streamReader.Close();
            return docText.ToString();
        }
    }

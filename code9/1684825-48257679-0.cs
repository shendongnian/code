    public static void SearchAndReplace(string document)
    {
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(document, true))
        {
            string docText = null;
            using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                docText = sr.ReadToEnd();
            Regex regexText = new Regex("@Address");
            string multiLineString = "Sample text.\nSample text.";
            multiLineString = multiLineString.Replace("\r\n", "\n")
                                             .Replace("\n", "<w:br/>");
            docText = regexText.Replace(docText, multiLineString);
            using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                sw.Write(docText);
        }
    }

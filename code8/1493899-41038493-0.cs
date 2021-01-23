    for (int x = 1; x <= pdfReader.NumberOfPages; x++)
    {
        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
        string currentText = "";                                
        currentText = PdfTextExtractor.GetTextFromPage(pdfReader, x, strategy);                        
        s.Add(currentText);
    }

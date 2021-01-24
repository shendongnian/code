    private static void InsertTextToPdf(string sourceFileName, string newFileName)
    {
        using (Stream pdfStream = new FileStream(sourceFileName, FileMode.Open))
        using (Stream newpdfStream = new FileStream(newFileName, FileMode.Create, FileAccess.ReadWrite))
        {
            PdfReader pdfReader = new PdfReader(pdfStream);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, newpdfStream);
            var parser = new PdfReaderContentParser(pdfReader);
            for (var i = 1; i <= pdfReader.NumberOfPages; i++)
            {
                parser.ProcessContent(i, (new ImageEntitlingRenderListener(pdfStamper, i)));
            }
            pdfStamper.Close();
            pdfReader.Close();
        }
    }

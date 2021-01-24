    using (var pdfReader = new PdfReader([FILE TO PARSE]))
    {
        IExtRenderListener extRenderListener = new ExtRenderListener();
        // Loop through each page of the document
        for (var page = 1; page <= pdfReader.NumberOfPages; page++)
        {
            Console.Write("\nPage {0}\n====\n", page);
            PdfReaderContentParser parser = new PdfReaderContentParser(pdfReader);
            parser.ProcessContent(page, extRenderListener);
        }
    }

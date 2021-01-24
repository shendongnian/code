    StreamUtil.AddToResourceSearch(System.Reflection.Assembly.Load("iTextAsian"));
    StreamUtil.AddToResourceSearch(System.Reflection.Assembly.Load("iTextAsianCmaps"));
    var pdfReader = new PdfReader(@"selection.pdf");
    var pageText = PdfTextExtractor.GetTextFromPage(pdfReader, 1, new SimpleTextExtractionStrategy());
    Console.Out.Write("Content: {0}", pageText);

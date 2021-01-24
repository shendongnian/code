    foreach (var anno in annots)
    {
        var a = anno.GetPdfObject().CopyTo(masterPdfDoc);
        PdfAnnotation ano = PdfAnnotation.MakeAnnotation(a);
        var apDict = ano.GetAppearanceDictionary();
        if (apDict == null)
        {
            Console.WriteLine("No appearances.");
            continue;
        }
        foreach (PdfName key in apDict.KeySet())
        {
            Console.WriteLine("Appearance: {0}", key);
            PdfStream value = apDict.GetAsStream(key);
            if (value != null)
            {
                var text = ExtractAnnotationText(value);
                Console.WriteLine("Extracted Text: {0}", text);
                if (text != "")
                {
                    var valueString = Encoding.ASCII.GetString(value.GetBytes());
                    value.SetData(Encoding.ASCII.GetBytes(valueString.Replace(text, "COMMENT: " + text)));
                                    }
                                }
                            }
        masterDocPage.AddAnnotation(ano);
    }
    public static String ExtractAnnotationText(PdfStream xObject)
    {
       PdfResources resources = new PdfResources(xObject.GetAsDictionary(PdfName.Resources));
       ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();
       PdfCanvasProcessor processor = new PdfCanvasProcessor(strategy);
       processor.ProcessContent(xObject.GetBytes(), resources);
       var text = strategy.GetResultantText();
       return text;
    }

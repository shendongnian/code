    var fixedMarkup = FixBrokenMarkup(PASTEBIN);
    // swap initialization to verify plain-text works too
    // var fixedMarkup = FixBrokenMarkup("some text");
    
    using (var stream = new MemoryStream())
    {
        using (var document = new Document())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, stream);
            document.Open();
            using (var stringReader = new StringReader(fixedMarkup))
            {
                XMLWorkerHelper.GetInstance().ParseXHtml(
                    writer, document, stringReader
                );
            }
        }
        File.WriteAllBytes(OUTPUT, stream.ToArray());
    }

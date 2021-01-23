    using (var stream = new MemoryStream())
    {
        var header = new PageEventHeader();
        using (Document document = new Document())
        {
            var writer = PdfWriter.GetInstance(document, stream);
            document.Open();
    
            writer.PageEvent = header;
            header.HeaderText = "Header 0";
            document.Add(new Phrase("Header 0"));
            document.NewPage();
            header.HeaderText = "Header 1";
            document.Add(new Phrase("Header 1"));
        }
        File.WriteAllBytes(OUTPUT_FILE, stream.ToArray());
    }

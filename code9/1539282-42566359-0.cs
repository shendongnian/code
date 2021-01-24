    var html = "<h1>H1</h1>";
    var css = "h1 {font-size: 2em;}";
    
    using (var htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(html)))
    {
        using (var cssStream = new MemoryStream(Encoding.UTF8.GetBytes(css)))
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var document = new Document())
                {
                    PdfWriter writer = PdfWriter.GetInstance(
                        document, memoryStream
                    );
                    document.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(
                        writer, document, htmlStream, cssStream
                    );
                }
                File.WriteAllBytes(OUTPUT_FILE, memoryStream.ToArray());
            }
        }
    }

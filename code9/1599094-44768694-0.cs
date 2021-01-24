    using (var stream = new MemoryStream())
    {
        using (var document = new Document())
        {
            PdfWriter.GetInstance(document, stream);
            document.Open();
            var image = Image.GetInstance(
                Resources.LOGO, System.Drawing.Imaging.ImageFormat.Png
            );
            document.Add(image);
        }
        File.WriteAllBytes(OUTPUT_FILE, stream.ToArray());
    }

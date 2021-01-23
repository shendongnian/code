    using (var pdfStream = new MemoryStream(_underlyingBytes))
    {
        PdfReader.unethicalreading = true;
        using (var reader = new PdfReader(pdfStream))
        {
            if (reader.NumberOfPages < 1) throw new ArgumentException("PDF has no pages");
            using (var document = new Document(reader.GetPageSizeWithRotation(1)))
            {
                using (var outputStream = new MemoryStream())
                {
                    using (var pdfCopyProvider = new PdfCopy(document, outputStream))
                    {
                        document.Open();
                        var importedPage = pdfCopyProvider.GetImportedPage(reader, 1);
                        pdfCopyProvider.AddPage(importedPage);
                        document.Close();
                        reader.Close();
                        _underlyingBytes = outputStream.ToArray();
                        return this;
                    }
                }
            }
        }
    }

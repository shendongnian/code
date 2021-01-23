    public byte[] MergePdfFiles(IEnumerable<byte[]> files)
    {
        using (var stream = new MemoryStream())
        {
            var pdfDoc = new iTextSharp.text.Document();
            var pdf = new PdfSmartCopy(pdfDoc, stream);
            pdf.SetMergeFields();
    
            pdfDoc.Open();
    
            foreach (var file in files)
            {
                try
                {
                    pdf.AddDocument(new PdfReader(file));
                }
                catch (InvalidPdfException ex)
                {
                    _loggingServiceClient.Log(LogLevel.Error, ex);
                    throw;
                }
            }
    
            pdfDoc.Close();
    
            return stream.GetBuffer();
        }
    }

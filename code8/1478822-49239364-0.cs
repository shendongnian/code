        public byte[] CreatePdf()
        {
            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);
            document.Add(new Paragraph("Hello world!"));
            document.Close();
            return stream.ToArray();
        }

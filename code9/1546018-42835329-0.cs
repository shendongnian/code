    public void MssGet_Word_NumberOfPages(byte[] ssFileBinaryData, out int ssNumberOfPages) {
            // Load Word Document from this byte array
            Document loadedFromBytes = new Document(new MemoryStream(ssFileBinaryData));
            // Save Word to PDF byte array
            MemoryStream pdfStream = new MemoryStream();
            loadedFromBytes.Save(pdfStream, SaveFormat.Pdf);
            byte[] pdfBytes = pdfStream.ToArray();
            int pageCount;
            MemoryStream stream = new MemoryStream(pdfBytes);
            using (var r = new StreamReader(stream))
            {
                string pdfText = r.ReadToEnd();
                System.Text.RegularExpressions.Regex regx = new Regex(@"/Type\s*/Page[^s]");
                System.Text.RegularExpressions.MatchCollection matches = regx.Matches(pdfText);
                pageCount = matches.Count;
                ssNumberOfPages = pageCount;
            }
        }

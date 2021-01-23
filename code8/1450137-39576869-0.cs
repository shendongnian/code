        const string PdfLocation = @"C:\fakepath\output.pdf";
        static void Main(string[] args)
        {
            using (var pdfDoc = new Document())
            using (var fs = new FileStream(PdfLocation, FileMode.OpenOrCreate))
            using (var writer = PdfWriter.GetInstance(pdfDoc, fs))
            {
                pdfDoc.Open();
                var font = FontFactory.GetFont(FontFactory.COURIER_BOLD);
                // Doesn't use font
                var paragraph = new Paragraph("LINE 1");
                paragraph.Font = font;
                pdfDoc.Add(paragraph);
                // Doesn't use font
                var paragraph2 = new Paragraph();
                paragraph2.Add("LINE 2");
                paragraph2.Font = font;
                pdfDoc.Add(paragraph2);
                // Does use font
                var paragraph3 = new Paragraph();
                paragraph3.Font = font;
                paragraph3.Add("LINE 3"); // This must be done after setting the font
                pdfDoc.Add(paragraph3);
                var cb = writer.DirectContent;
                pdfDoc.Close();
            }
            // Remove font not in use
            using (var reader = new PdfReader(PdfLocation))
            {
                reader.RemoveUnusedObjects();
                reader.Close();
            }
        }

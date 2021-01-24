        public static void ScaleToA4self(byte[] pdfAsBinary, string locationOfPdfOut)
        {
            PdfReader reader = new PdfReader(pdfAsBinary);
            Rectangle originalSize = reader.GetPageSize(1);
            float originalHeight = originalSize.Height;
            float originalWidth = originalSize.Width;
            Rectangle newSize = PageSize.A4;
            float newHeight = newSize.Height;
            float newWidth = newSize.Width;
            float scaleHeight = newHeight / originalHeight;
            float scaleWidth = newWidth / originalWidth;
            Document doc = new Document(newSize, 0, 0, 0, 0);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(locationOfPdfOut, FileMode.Create));
            doc.Open();
            PdfContentByte cb = writer.DirectContent;
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, scaleWidth, 0, 0, scaleHeight, 0, 0);
            doc.Close();
        }

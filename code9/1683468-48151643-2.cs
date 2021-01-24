    using (var reader = new PdfReader(pdfFilePath))
    {
        using (var fileStream = new FileStream(newPdf, FileMode.Create, FileAccess.Write))
        {
            Document document = new Document(reader.GetPageSizeWithRotation(1));                        
            PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
            document.Open();
            using (var pdfStamper = new PdfStamper(reader, fileStream))
            {                            
                for (int p = 0; p < pdfStamper.Reader.NumberOfPages; p++)                            
                {
                    // Add border to page
                    PdfContentByte content = writer.DirectContent;
                    Rectangle rectangle = new Rectangle(document.PageSize);
                    rectangle.Left += document.LeftMargin;
                    rectangle.Right -= document.RightMargin;
                    rectangle.Top -= document.TopMargin;
                    rectangle.Bottom += document.BottomMargin;
                    content.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
                    content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
                    content.Stroke();
                }
                document.Close();
                writer.Close();
            }
        }
    }

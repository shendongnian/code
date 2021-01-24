    using (var reader = new PdfReader(pdfFilePath))
    {
        using (var fileStream = new FileStream(newPdf, FileMode.Create, FileAccess.Write))
        {
            using (var pdfStamper = new PdfStamper(reader, fileStream))
            {                            
                for (int p = 1; p <= reader.NumberOfPages; p++)                            
                {
                    // Add border to page
                    PdfContentByte content = pdfStamper.GetOverContent(p);
                    Rectangle rectangle = new Rectangle(pdfReader.GetPageSize(p));
                    rectangle.Left += document.LeftMargin;
                    rectangle.Right -= document.RightMargin;
                    rectangle.Top -= document.TopMargin;
                    rectangle.Bottom += document.BottomMargin;
                    content.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
                    content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
                    content.Stroke();
                }
            }
        }
    }

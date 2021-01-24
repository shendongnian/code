    using (PdfReader reader = new PdfReader(source))
    using (PdfStamper stamper = new PdfStamper(reader, new FileStream(dest, FileMode.Create)))
    {
        for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber++)
        {
            Rectangle cropBox = reader.GetCropBox(pageNumber);
            Rectangle rectangle = new Rectangle(cropBox);
            rectangle.Left += 20;
            rectangle.Right -= 20;
            rectangle.Top -= 20;
            rectangle.Bottom += 20;
            PdfContentByte content = stamper.GetOverContent(pageNumber);
            content.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
            content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
            content.Stroke();
        }
    }

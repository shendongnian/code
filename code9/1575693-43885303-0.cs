        using (PdfReader pdfReader = new PdfReader(input))
        using (PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(output, FileMode.Create, FileAccess.Write)))
        {
            for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                Rectangle pageSize = pdfReader.GetPageSize(page);
                PdfContentByte canvas = pdfStamper.GetOverContent(page);
                canvas.SetColorFill(BaseColor.WHITE);
                canvas.Rectangle(pageSize.Left, pageSize.Bottom, pageSize.Width, pageSize.Height);
                canvas.Fill();
            }
        }

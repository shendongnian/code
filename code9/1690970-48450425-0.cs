    using (MemoryStream workStream = new MemoryStream())
    {
        iTextSharp.text.Document document = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(0, 0, 288, 360));
        PdfWriter.GetInstance(document, workStream).CloseStream = false;
    
        document.Open();
        iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(inputImageStream.ToArray());
        pdfImage.ScaleToFit(288, 360);
        pdfImage.SetAbsolutePosition(0, 0);
        document.Add(pdfImage);
        document.Close();
    
        byte[] byteInfo = workStream.ToArray();
        workStream.Write(byteInfo, 0, byteInfo.Length);
        workStream.Position = 0;
    
        return workStream.ToArray();
    }

    public void OnStartPage(PdfWriter writer, Document document)
    {
        float width = document.PageSize.Width;
        float height = document.PageSize.Height;
        try
        {
            PdfContentByte under = writer.DirectContentUnder;
            Image image = Image.GetInstance(watermarkText);              
            image.ScaleToFit(width, height);
            image.SetAbsolutePosition(0, 0);  
            under.AddImage(image);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }

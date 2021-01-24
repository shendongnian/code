    public void OnEndPage(PdfWriter writer, Document document)
    {
        float width = document.PageSize.Width;
        float height = document.PageSize.Height;
        try
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(watermarkText);
            image.ScaleToFit(275f, 275f);
            image.SetAbsolutePosition(150, 300);
            PdfGState gStateHue = new PdfGState();
            gStateHue.BlendMode = new PdfName("Hue");
            PdfGState gStateScreen = new PdfGState();
            gStateScreen.BlendMode = new PdfName("Screen");
            PdfContentByte under = writer.DirectContentUnder;
            under.SaveState();
            under.SetColorFill(BaseColor.WHITE);
            under.Rectangle(document.PageSize.Left, document.PageSize.Bottom, document.PageSize.Width, document.PageSize.Height);
            under.Fill();
            under.AddImage(image);
            under.SetGState(gStateHue);
            under.SetColorFill(BaseColor.WHITE);
            under.Rectangle(document.PageSize.Left, document.PageSize.Bottom, document.PageSize.Width, document.PageSize.Height);
            under.Fill();
            under.SetGState(gStateScreen);
            under.SetColorFill(BaseColor.LIGHT_GRAY);
            under.Rectangle(document.PageSize.Left, document.PageSize.Bottom, document.PageSize.Width, document.PageSize.Height);
            under.Fill();
            under.RestoreState();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }

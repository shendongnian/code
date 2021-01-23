    try
    {
        using (var document = PdfiumViewer.PdfDocument.Load(@"C:\Users\ohernandez\Pictures\img\descarga.pdf"))
        {
            for (int index = 0; index < document.PageCount; index++)
            {
                var image = document.Render(index, 300, 300, PdfRenderFlags.CorrectFromDpi);
                image.Save(@"C:\Users\ohernandez\Pictures\img\output.Jpeg" + index.ToString("000") + ".Jpeg", ImageFormat.Jpeg);
            }
        //    var image = document.Render(0, 300, 300, true);
         //   image.Save(@"C:\Users\ohernandez\Pictures\img\output.png", ImageFormat.Png);
        }
    }
    catch (Exception ex)
    {
        // handle exception here;
    }

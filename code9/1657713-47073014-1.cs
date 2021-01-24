    var imagePath = "logo.png";
    var pdfPath = "edit_this.pdf";
    //load pdf file
    var pdfBytes = File.ReadAllBytes(pdfPath);
    var oldFile = new PdfReader(pdfBytes);
    //load image
    var preImage = System.Drawing.Image.FromFile(imagePath);
    var image = Image.GetInstance(preImage, ImageFormat.Png);
    preImage.Dispose();
    //optional: if image is wider than the page, scale down the image to fit the page
    var sizeWithRotation = oldFile.GetPageSizeWithRotation(1);
    if (image.Width > sizeWithRotation.Width)
        image.ScalePercent(sizeWithRotation.Width / image.Width * 100);
    
    //set image position in top left corner
    //in pdf files, cooridinates start in the left bottom corner
    image.SetAbsolutePosition(0, sizeWithRotation.Height - image.ScaledHeight);
    
    //in production, I use MemoryStream
    //I put FileStream here to test the code in console application
    var newFileStream = new FileStream("with_logo.pdf", FileMode.Create);
    
    //setup PdfWriter
    var doc = new Document(sizeWithRotation);
    var writer = PdfWriter.GetInstance(doc, newFileStream);
    
    doc.Open();
    
    //iterate through the pages in the original file
    for (var i = 1; i <= oldFile.NumberOfPages; i++)
    {
        //create a page in the new pdf
        doc.NewPage();
        //take the original page
        var page = writer.GetImportedPage(oldFile, i);
        //insert original page in the new pdf
        writer.DirectContentUnder.AddTemplate(page, 0, 0);
    
        //add the image
        writer.DirectContentUnder.SaveState();
        writer.DirectContentUnder.AddImage(image);
        writer.DirectContentUnder.RestoreState();
    }
    
    doc.Close();
    writer.Close();
    newFileStream.Close();

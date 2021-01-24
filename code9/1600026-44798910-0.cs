    Aspose.Pdf.Document document = new Aspose.Pdf.Document(dataDir + @"input.pdf");
    
    var resolution = new Aspose.Pdf.Devices.Resolution(100);
    var bmpDevice = new Aspose.Pdf.Devices.BmpDevice(resolution);
    
    // Export image file to stream
    MemoryStream bmpStream = new MemoryStream();
    bmpDevice.Process(document.Pages[1], bmpStream);
    
    
    Document doc = new Document();
    Page currpage = doc.Pages.Add();
    Aspose.Pdf.Image img = new Aspose.Pdf.Image();
    img.ImageStream = bmpStream;
    img.ImageScale = 1;
    currpage.PageInfo.Margin.Top = currpage.PageInfo.Margin.Bottom = currpage.PageInfo.Margin.Right = currpage.PageInfo.Margin.Left = 0;
    currpage.Paragraphs.Add(img);
    
    doc.Save(dataDir + "output.pdf");

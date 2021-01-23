    // Create a new PDF document
    PdfDocument document = new PdfDocument();
     
    // Create a font
    XFont font = new XFont("Times", 25, XFontStyle.Bold);
     
    PageSize[] pageSizes = (PageSize[])Enum.GetValues(typeof(PageSize));
    foreach (PageSize pageSize in pageSizes)
    {
      if (pageSize == PageSize.Undefined)
        continue;
     
      // One page in Portrait...
      PdfPage page = document.AddPage();
      page.Size = pageSize;
      XGraphics gfx = XGraphics.FromPdfPage(page);
      gfx.DrawString(pageSize.ToString(), font, XBrushes.DarkRed,
        new XRect(0, 0, page.Width, page.Height),
        XStringFormat.Center);
     
      // ... and one in Landscape orientation.
      page = document.AddPage();
      page.Size = pageSize;
      page.Orientation = PageOrientation.Landscape;
      gfx = XGraphics.FromPdfPage(page);
      gfx.DrawString(pageSize.ToString() + " (landscape)", font,
        XBrushes.DarkRed, new XRect(0, 0, page.Width, page.Height),
        XStringFormat.Center);
    }
     
    // Save the document...
    string filename = "PageSizes.pdf";
    document.Save(filename);
    // ...and start a viewer.
    Process.Start(filename);
